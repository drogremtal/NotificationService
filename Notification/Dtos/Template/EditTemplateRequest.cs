namespace NotificationService.Dtos.Template
{
    public record EditTemplateRequest(Guid Id, string Name,string Description, string Type, string Template);
}
