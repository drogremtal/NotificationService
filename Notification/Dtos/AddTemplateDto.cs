namespace NotificationService.Dtos
{

    /// <summary>
    /// Модель для создания
    /// </summary>
    /// <param name="Name">Наименование шаблона</param>
    /// <param name="Description">Описание шаблона</param>
    /// <param name="Type">Тип шаблона (от какого сервиса)</param>
    /// <param name="Subject">Тема сообщения</param>
    /// <param name="Template">Шаблон</param>
    public record AddTemplateRequest(string Name,string Description, string Type, string Subject,  string Template);

}
