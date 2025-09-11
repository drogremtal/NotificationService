namespace NotificationService.Dtos.Template
{
    public record TemplateResponse(
    Guid Id ,
    string Name ,
    string Description,
    string Type ,
    string Subject,
    bool Enabled ,
    DateTime CreatedDate,
    DateTime? UpdatedDate ,
    string AuthtorCreated ,
    string? AuthtorUpdated,
    string Template
    );
}
