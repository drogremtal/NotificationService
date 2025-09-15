using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Email
{
    public class FakeEmailService : ISmtpEmailService
    {
        public async Task<bool> SendMessage(EmailNotification emailNotification)
        {

            var notification = @$"

                {emailNotification.IsHtml}
                {emailNotification.Recipient}
                {emailNotification.ReplyTo}
                {emailNotification.Subject}
                {emailNotification.Body}";

            Console.WriteLine(notification);
            return true;
        }


    }
}
