namespace NotificationService.Domain.Entities
{
    public sealed class NotificationEntity
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime? SentAt { get; set; }
        public string Metadata { get; set; } = string.Empty;

        public TemplateEntity Template { get; set; }
    }
}
