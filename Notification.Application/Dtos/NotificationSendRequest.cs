namespace NotificationService.Application.Dtos
{

    /// <summary>
    /// Объект из топика
    /// </summary>
    public class NotificationSendRequest
    {
        public required string Recipient { get; set; }
        public string Subject { get; set; }

        public string Type { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public bool IsHtml { get; set; } = false;
        public string? ReplyTo { get; set; }

    }
}
