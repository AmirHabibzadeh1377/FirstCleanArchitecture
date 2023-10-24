using CleanArchitecture.MVC3.Model;
using CleanArchitecture.MVC3.Model.ViewModels.Weblog;

namespace CleanArchitecture.MVC3.Contract
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