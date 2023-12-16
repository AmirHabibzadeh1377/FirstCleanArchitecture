using CleanArichitecture.Application.Models.Idnetity;
using CleanArichitecture.Application.Persistence.ServiceContract.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [Route("getProvider")]
        public ActionResult<AuthenticationProperties> GetProvider(ProviderRequest request)
        {
            return Ok(_authenticationService.GetProvider(request.Provider, request.RedirectUrl));
        }

        [Route("externalLogin")]
        public async Task<ActionResult> ExternalLogin()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var externalResponse = await _authenticationService.ExternalLogn(userEmail);
            if (externalResponse.Success)
            {
                await HttpContext.SignInAsync(externalResponse.ClaimsPrincipal, externalResponse.AuthenticationProperties);
            }

            return Content("");
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }
    }
}