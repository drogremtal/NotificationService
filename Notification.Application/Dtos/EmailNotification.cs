namespace NotificationService.Application.Dtos
{
    public class EmailNotification
    {
   
        public string Recipient { get; set; }
        public bool IsHtml { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}