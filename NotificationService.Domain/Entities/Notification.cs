using NotificationService.Domain.Enum;

namespace NotificationService.Domain.Model
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public NotificationType Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsSent { get; set; }
        public int RetryCount { get; set; }
    }
}
