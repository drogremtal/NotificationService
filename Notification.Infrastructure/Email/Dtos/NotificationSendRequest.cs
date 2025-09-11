namespace Notification.Infrastructure.Email.Dtos
{

    /// <summary>
    /// Объект из топика
    /// </summary>
    public class NotificationSendRequest
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public bool IsHtml { get; set; }
        public string Recipient { get; set; }
        public string? ReplyTo { get; set; }
        public string Type { get; set; }
    }
}