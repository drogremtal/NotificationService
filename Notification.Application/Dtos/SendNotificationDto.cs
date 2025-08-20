using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Dtos
{
    public sealed class SendNotificationDto
    {
        public string Type { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, object>? Metadata { get; set; }
        public string? TemplateId { get; set; }
        public int Priority { get; set; } = 1;
        public DateTime? ScheduleFor { get; set; }

    }
}
