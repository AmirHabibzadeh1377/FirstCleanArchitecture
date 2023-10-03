using AutoMapper;
using CleanArchitecture.Domain.Entities.Weblog;
using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.DTOs.WeblogCategory;

namespace CleanArichitecture.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Weblog, Weblog>().ReverseMap();
            CreateMap<Weblog, WeblogDTOs>().ReverseMap();
            CreateMap<Weblog, WeblogListDTOs>().ReverseMap();
            CreateMap<WeblogCategory, WeblogCategoryDTOs>().ReverseMap();
        }
    }
}