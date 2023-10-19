using CleanArchitecture.MVC.Model;
using CleanArchitecture.MVC.Model.ViewModels.Weblog;

namespace CleanArchitecture.MVC.Contract
{
    public interface IWeblogServiceContract
    {
        Task<GenericResponseApi<int>> CreateWeblog(CreateWeblogVM model);
        Task<GenericResponseApi<int>> UpdateWeblog(UpdateWeblogVM model);
        Task<List<WeblogListVM>> GetAllWeblogList();
        Task<WeblogListVM> GetWeblogById(int weblogId);
        Task<GenericResponseApi<int>> DeleteWeblog(int weblogId);
    }
}