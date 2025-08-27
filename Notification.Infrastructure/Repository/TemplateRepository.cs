using NotificationService.Domain.Entities;
using NotificationService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Repository
{
    public class TemplateRepository : ITemplateRepository
    {
        public Task Create(TemplateEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TemplateEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TemplateEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TemplateEntity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
