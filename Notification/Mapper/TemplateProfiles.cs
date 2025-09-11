using AutoMapper;
using NotificationService.Application.Dtos;
using NotificationService.Domain.Entities;
using NotificationService.Dtos.Template;

namespace NotificationService.Mapper
{
    public class TemplateProfiles:Profile
    {
        public TemplateProfiles()
        {
            CreateMap<AddTemplateRequest, TemplateDto>();
            CreateMap<EditTemplateRequest, TemplateDto>();
            CreateMap<TemplateDto, TemplateEntity>().ReverseMap();
            CreateMap<TemplateDto,TemplateResponse>();
        }
    }
}
