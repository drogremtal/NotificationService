using AutoMapper;
using NotificationService.Application.Dtos;

namespace NotificationService.Dtos.Mapper
{
    public class TemplateProfiles:Profile
    {
        public TemplateProfiles()
        {
            CreateMap<AddTemplateDto, Template>();
            CreateMap<EditTemplateDto, Template>();
        }
    }
}
