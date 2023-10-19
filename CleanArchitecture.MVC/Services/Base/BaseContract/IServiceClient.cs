using CleanArchitecture.MVC.Model;
using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.Responses;

namespace CleanArchitecture.MVC.Services.Base
{
    public partial interface IClient
    {
        Task<ICollection<WeblogListDTOs>> GetWeblogDTO();
        Task<BaseCommandResponse> CreateWeblogDTO(CreateWeblogDTOs model);
        Task<BaseCommandResponse> UpdateWeblog(UpdateWeblogDTOs model);
        Task<WeblogListDTOs> GetWeblogById(int id);
        Task<BaseCommandResponse> DeleteWeblog(int id);
    }
}
