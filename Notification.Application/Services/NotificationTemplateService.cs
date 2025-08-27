using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Services
{
    public class NotificationTemplateService:INotificationTemplateService
    {
        public List<Template> GetList()
        {
            throw new NotImplementedException();
        }

        public Template Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Add(TemplateCreate item)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, TemplateCreate item)
        {
            throw new NotImplementedException();
        }
    }
}
