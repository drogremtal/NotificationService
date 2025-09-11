namespace NotificationService.Dtos
{
    public sealed class SendNotificationRequest
    {
        public string Recipient { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; }

    }
}
