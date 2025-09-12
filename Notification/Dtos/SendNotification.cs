namespace NotificationService.Dtos
{  
    /// <summary>
    /// Для отправки сообщения
    /// </summary>
    /// <param name="Recipient"></param>
    /// <param name="Title"></param>
    /// <param name="Message"></param>
    public record SendNotificationRequest(string Recipient, string Title, string Message);
}
