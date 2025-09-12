namespace NotificationService.Dtos
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Recipient"></param>
    /// <param name="Subject"></param>
    /// <param name="Type"></param>
    /// <param name="Parameters"></param>
    public record SendNotificationRequestMq(
        string Recipient,
        string Subject,
        string Type,
        Dictionary<string, string> Parameters);
}

