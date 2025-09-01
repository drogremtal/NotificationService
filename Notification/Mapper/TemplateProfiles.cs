using AutoMapper;
using NotificationService.Application.Dtos;
using NotificationService.Domain.Entities;
using NotificationService.Dtos;

namespace NotificationService.Mapper
{
    public class TemplateProfiles:Profile
    {
        public TemplateProfiles()
        {
            CreateMap<AddTemplateDto, TemplateDto>();
            CreateMap<EditTemplateDto, TemplateDto>();
            CreateMap<TemplateDto, TemplateEntity>();

            CreateMap<TemplateDto,TemplateResponseDto>();

        }
    }
}
