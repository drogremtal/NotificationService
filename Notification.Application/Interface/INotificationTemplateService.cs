using NotificationService.Application.Dtos;
using System;
using System.Linq;

namespace NotificationService.Application.Interface
{
    public interface INotificationTemplateService
    {
        Task<List<TemplateDto>> GetList();
        Task<TemplateDto> Get(Guid id);
        Task Delete(Guid id);
        Task SetEnabled(Guid id);
        Task Add(TemplateDto item);
        Task Update(Guid id, TemplateDto item);
        Task<TemplateDto> GetTemplateByType(string type);
    }
}
