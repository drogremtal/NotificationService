namespace Notification.Infrastructure.Email.Dtos
{
    public class EmailNotification
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsHtml { get; set; }
        public string Recipient { get; set; }
        public string? ReplyTo { get; set; }
        public string Type { get; set; }
        //public List<object> Attachments { get; internal set; }
    }
}