using AutoMapper;
using Microsoft.Extensions.Logging;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Interface;

namespace NotificationService.Application.Services
{
    public class NotificationTemplateService : INotificationTemplateService
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NotificationTemplateService> _logger;

        public NotificationTemplateService(ITemplateRepository templateRepository, IMapper mapper, ILogger<NotificationTemplateService> logger)
        {
            _mapper = mapper;
            _templateRepository = templateRepository;
            _logger = logger;
        }
        public async Task<List<TemplateDto>> GetList()
        {
            var res = await _templateRepository.GetAll();
            var templates = _mapper.Map<List<TemplateDto>>(res);
            return templates;
        }

        public async Task<TemplateDto> Get(Guid id)
        {
            var res = await _templateRepository.GetById(id);
            var templates = _mapper.Map<TemplateDto>(res);
            return templates;
        }

        public async Task Delete(Guid id)
        {
            var entity = await _templateRepository.GetById(id);
            await _templateRepository.Delete(entity);
        }

        public async Task Add(TemplateDto item)
        {
            item.CreatedDate = DateTime.Now.Date;
            item.AuthtorCreated = "Guest";

            var entity = _mapper.Map<TemplateEntity>(item);
            await _templateRepository.Create(entity);
        }

        public async Task Update(Guid id, TemplateDto item)
        {

            var data = await _templateRepository.GetById(id);
            data.Id = id;
            data.Name = item.Name;
            data.Description = item.Description;
            data.Type = item.Type;
            data.Subject = item.Subject;
            data.Template = item.Template;

            await _templateRepository.Update(data);
        }

        public async Task SetEnabled(Guid id)
        {
            var entity = await _templateRepository.GetById(id);
            entity.UpdatedDate = DateTime.Now.Date;
            entity.Enabled = !entity.Enabled;

            await _templateRepository.Update(entity);
        }
    }
}
