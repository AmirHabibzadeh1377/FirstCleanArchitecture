using CleanArchitecture.MVC3.Services.Base;

using MVC3.Model;

namespace MVC3.Contract
{
    public interface IAuthenticationsServiceContract
    {
        Task<bool> Authentication(string email, string password);
        Task<bool> Register(RegisterModel model);
        Task LogOut();
    }
}
