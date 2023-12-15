using CleanArichitecture.Application.Models.Idnetity;
using CleanArichitecture.Application.Persistence.ServiceContract.Identity;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClearnArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Fields

        private readonly IAuthenticationsService _authenticationService;

        #endregion

        #region Ctor

        public AccountController(IAuthenticationsService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        #endregion 

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest reques)
        {
            return Ok(await _authenticationService.Login(reques));
        }

        [HttpPost("getProvider")]
        public async Task<ActionResult> GetProvider(string provider)
        {
            var redirectUrl = Url.RouteUrl("/ExternalLogin");
            var properties = _authenticationService.GetProvider(provider, redirectUrl);
            return Challenge(properties,provider);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>>  Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }
    }
}
