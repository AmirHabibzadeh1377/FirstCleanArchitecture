using CleanArichitecture.Application.Models.Idnetity;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace CleanArichitecture.Application.Persistence.ServiceContract.Identity
{
    public interface IAuthenticationsService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        AuthenticationProperties GetProvider(string provider, string redirectUrl);
        Task<ExternalResponse> ExternalLogn(string email);
    }
}