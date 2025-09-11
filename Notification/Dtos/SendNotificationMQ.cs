namespace NotificationService.Dtos
{
    public sealed class SendNotificationRequestMQ
    {
        public string Recipient { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public Dictionary<string,string> Parameters { get; set; }

    }
}
