using AutoMapper;
using Microsoft.EntityFrameworkCore.Design.Internal;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Services
{
    public class NotificationTemplateService : INotificationTemplateService
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;
        public NotificationTemplateService(ITemplateRepository templateRepository, IMapper mapper)
        {
            _mapper = mapper;
            _templateRepository = templateRepository;
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
   
        }

        public async Task Add(TemplateCreate item)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Guid id, TemplateCreate item)
        {
            throw new NotImplementedException();
        }
    }
}
