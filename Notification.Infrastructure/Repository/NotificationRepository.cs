using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Interface;
using NotificationService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _dbContext.Notifications.AddAsync(notification);
            _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(NotificationEntity notification)
        {
            throw new NotImplementedException();
        }

        public Task MarkAsReadAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
