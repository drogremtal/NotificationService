using NotificationService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Interface
{
    public interface ITemplateRepository
    {
        Task Create(TemplateEntity entity);
        Task Delete(TemplateEntity entity);
        Task<TemplateEntity> GetById(Guid id);
        Task<IEnumerable<TemplateEntity>> GetAll();

    }
}
