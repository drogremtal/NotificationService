namespace NotificationService.Dtos
{  
    /// <summary>
    /// Для отправки сообщения
    /// </summary>
    /// <param name="Recipient"></param>
    /// <param name="Subject"></param>
    /// <param name="Message"></param>
    public record SendNotificationRequest(string Recipient, string Subject, string Message);
}
