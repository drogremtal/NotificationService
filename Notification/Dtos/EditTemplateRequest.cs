namespace NotificationService.Dtos
{
    public record EditTemplateRequest(Guid Id, string Name,string Description, string Type, string Template);
}
