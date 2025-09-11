using Notification.Infrastructure.Email.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Interface
{
    public interface INotificationProcessor
    {
        Task ProcessNotificationAsync(string message,CancellationToken token);


        Task<string> PrepareEmailAsync(NotificationSendRequest emailNotification);
    }
}
