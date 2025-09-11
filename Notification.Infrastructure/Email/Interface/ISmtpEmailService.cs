using Notification.Infrastructure.Email.Dtos;
using NotificationService.Infrastructure.Email.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.Email.Interface
{
    public interface ISmtpEmailService
    {
        Task<bool> SendMessage(EmailNotification emailNotification);
    }

}
