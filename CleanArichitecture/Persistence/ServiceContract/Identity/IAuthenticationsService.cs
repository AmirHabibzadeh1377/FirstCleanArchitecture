using CleanArichitecture.Application.Models.Idnetity;

using System.Threading.Tasks;

namespace CleanArichitecture.Application.Persistence.ServiceContract.Identity
{
    public interface IAuthenticationsService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}