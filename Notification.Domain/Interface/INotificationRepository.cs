using NotificationService.Domain.Entities;

namespace NotificationService.Domain.Interface
{
    public interface INotificationRepository
    {
        Task<NotificationEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<NotificationEntity>> GetByRecipientAsync(string recipient);
        Task AddAsync(NotificationEntity notification);
        Task UpdateAsync(NotificationEntity notification);
        Task MarkAsReadAsync(Guid id);

    }
}
