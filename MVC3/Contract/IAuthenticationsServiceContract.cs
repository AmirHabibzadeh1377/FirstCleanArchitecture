using CleanArichitecture.Application.Models.Idnetity;
using Microsoft.AspNetCore.Authentication;
using MVC3.Model.ViewModels.UserAccount;

namespace MVC3.Contract
{
    public interface IAuthenticationsServiceContract
    {
        Task<bool> Authentication(string email, string password);
        Task<bool> Register(RegisterVM model);
        Task<AuthenticationProperties> GetProvider(ProviderRequest request);
        Task<bool> ExternalLogin();
        Task LogOut();
    }
}