using System;
using System.Linq;

namespace NotificationService.Domain.Entities
{
    public class TemplateEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Template { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string AuthtorCreated { get; set; }
        public string? AuthtorUpdated { get; set; }


        public ICollection<NotificationEntity>? NotificationsCollection { get; set; }

    }
}
