using CleanArichitecture.Application.DTOs.Weblog;
using CleanArichitecture.Application.Models.Idnetity;
using CleanArichitecture.Application.Responses;

using Microsoft.AspNetCore.Authentication;

namespace CleanArchitecture.MVC3.Services.Base
{
    public partial interface IClient
    {
        Task<ICollection<WeblogListDTOs>> GetWeblogDTO();
        Task<BaseCommandResponse> CreateWeblogDTO(CreateWeblogDTOs model);
        Task<BaseCommandResponse> UpdateWeblog(UpdateWeblogDTOs model);
        Task<WeblogListDTOs> GetWeblogById(int id);
        Task<BaseCommandResponse> DeleteWeblog(int id);
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<ExternalResponse> ExternalLogin();
        Task<AuthenticationProperties> GetProvider(ProviderRequest request);
    }
}