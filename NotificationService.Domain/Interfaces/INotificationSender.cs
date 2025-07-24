using NotificationService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Core.Interfaces
{


    /// <summary>
    /// интерфейс для отправки email, sms и т.д.
    /// </summary>
    public interface INotificationSender
    {
        Task SendAsync(Notification notification);
    }
}
