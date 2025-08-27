namespace NotificationService.Dtos
{
    public record EditTemplateDto(Guid Id, string Name,string Description, string Type, string Template);
}
