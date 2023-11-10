using MVC3.Model.ViewModels.UserAccount;

namespace MVC3.Contract
{
    public interface IAuthenticationsServiceContract
    {
        Task<bool> Authentication(string email, string password);
        Task<bool> Register(RegisterVM model);
        Task LogOut();
    }
}
