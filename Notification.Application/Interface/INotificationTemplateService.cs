using NotificationService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
    }
}
