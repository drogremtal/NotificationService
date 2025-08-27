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
        List<Template> GetList();
        Template Get(Guid id);
        void Delete(Guid id);
        Task Add(TemplateCreate item);
        void Update(Guid id,TemplateCreate item);
    }
}
