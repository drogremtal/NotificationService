namespace NotificationService.Dtos
{
    public record TemplateResponseDto(
        Guid Id,
        string Name,
        string Description,
        string Type,
        string Template);
}
