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
            #region WeblogDTos

            CreateMap<Weblog, Weblog>().ReverseMap();
            CreateMap<Weblog, WeblogDTOs>().ReverseMap();
            CreateMap<Weblog, WeblogListDTOs>().ReverseMap();
            CreateMap<Weblog, UpdateWeblogDTOs>().ReverseMap();
            CreateMap<Weblog, CreateWeblogDTOs>().ReverseMap();

            #endregion

            #region WeblogCategory

            CreateMap<WeblogCategory, WeblogCategoryDTOs>().ReverseMap();
            CreateMap<WeblogCategory, WeblogCategoryListDTOs>().ReverseMap();
            CreateMap<WeblogCategory, CreateWeblogCategoryDTOs>().ReverseMap();
            CreateMap<WeblogCategory, UpdateWeblogCategoryDTOs>().ReverseMap();

            #endregion
        }
    }
}