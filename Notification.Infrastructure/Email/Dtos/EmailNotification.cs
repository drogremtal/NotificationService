namespace NotificationService.Infrastructure.Email.Dtos
{
    public class EmailNotification
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public string Recipient { get; set; }
        public string? ReplyTo { get; set; }
    }
}