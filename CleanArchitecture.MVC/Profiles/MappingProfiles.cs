using AutoMapper;
using CleanArchitecture.MVC.Model.ViewModels.Weblog;
using CleanArchitecture.MVC.Model.ViewModels.WeblogCategory;
using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.DTOs.WeblogCategory;

namespace CleanArchitecture.MVC.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            #region Weblog

            CreateMap<CreateWeblogDTOs, CreateWeblogVM>().ReverseMap();
            CreateMap<UpdateWeblogDTOs, UpdateWeblogVM>().ReverseMap();
            CreateMap<WeblogListDTOs, WeblogListVM>().ReverseMap();
            CreateMap<UpdateWeblogVM, WeblogListVM>().ReverseMap();

            #endregion

            #region WeblogCategory

            CreateMap<CreateWeblogCategoryDTOs, CreateWeblogCategoryVM>().ReverseMap();
            CreateMap<UpdateWeblogCategoryDTOs,UpdateWeblogCategoryDTOs>().ReverseMap();
            CreateMap<WeblogCategoryListDTOs, WeblogCategoryListVM>().ReverseMap();
            CreateMap<WeblogCategoryDTOs, WeblogCategoryVM>().ReverseMap();

            #endregion
        }
    }
}
