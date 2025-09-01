using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Data;
using NotificationService.Infrastructure.Interface;

namespace NotificationService.Infrastructure.Repository
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly NotificationDbContext _dbContext;

        public TemplateRepository(NotificationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task Create(TemplateEntity entity)
        {
            await _dbContext.Templates.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(TemplateEntity entity)
        {
            _dbContext.Templates.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TemplateEntity>> GetAll()
        {          
            return await _dbContext.Templates.ToListAsync();
        }

        public async Task Update(TemplateEntity entity)
        {
            _dbContext.Templates.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task<TemplateEntity> GetById(Guid id)
        {
            return await _dbContext.Templates.Where(q => q.Id == id).FirstOrDefaultAsync();
        }
    }
}
