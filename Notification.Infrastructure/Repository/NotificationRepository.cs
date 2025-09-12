using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Data;
using NotificationService.Infrastructure.Interface;

namespace NotificationService.Infrastructure.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationDbContext _dbContext;
        public NotificationRepository(NotificationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<NotificationEntity?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NotificationEntity>> GetByRecipientAsync(string recipient)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(NotificationEntity notification)
        {
           await _dbContext.Notifications.AddAsync(notification);
           await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(NotificationEntity notification)
        {
            _dbContext.Update(notification);
            await _dbContext.SaveChangesAsync();
        }

        public Task MarkAsReadAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
