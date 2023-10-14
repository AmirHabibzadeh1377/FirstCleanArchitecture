using CleanArichitecture.Application.DTOs.Weblog;

namespace CleanArchitecture.MVC.Services.Base
{
    public partial interface IClient
    {
        Task<ICollection<WeblogListDTOs>> GetWeblogDTOd();
        Task CreateWeblogDTO();
        Task UpdateWeblog(UpdateWeblogDTOs model);
        Task<WeblogListDTOs> GetWeblogById(int id);
        Task DeleteWeblog(int id);
    }
}
