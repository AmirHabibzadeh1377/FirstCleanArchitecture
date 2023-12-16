using CleanArchitecture.MVC3;
using CleanArchitecture.MVC3.Services.Base;
using CleanArichitecture.Application.Models.Idnetity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MVC3.Contract;
using MVC3.Model.ViewModels.UserAccount;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;

namespace MVC3.Services
{
    public class AuthenticationRepository : BaseHttpResponse, IAuthenticationsServiceContract
    {
        #region Fields

        private readonly IHttpContextAccessor _contextAccessor;
        JwtSecurityTokenHandler jwtSecurityTokenHandler;
        private readonly ILogger _logger;

        #endregion

        #region Ctor

        public AuthenticationRepository(IHttpContextAccessor contextAccessor, IClient client, ILocalStorageServiceContract localStorageService, ILogger logger = null)
            : base(localStorageService, client)
        {
            _contextAccessor = contextAccessor;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _logger = logger;
        }

        #endregion

        #region Methods

        public async Task<bool> Authentication(string email, string password)
        {
            try
            {
                var authRequest = new AuthRequest { Email = email, Password = password };
                var authResponse = await _client.Login(authRequest);
                if (!string.IsNullOrWhiteSpace(authResponse.Token))
                {
                    var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(authResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                    await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                    _localStorageService.SetLocalStorage("token", authResponse.Token);
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task LogOut()
        {
            _localStorageService.ClearLocalStorage(new List<string> { "token" });
            await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Register(RegisterVM model)
        {
            try
            {
                var register = new RegistrationRequest
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password,
                    UserName = model.Email
                };

                var response = await _client.Register(register);
                if (!string.IsNullOrWhiteSpace(response.UserId))
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<AuthenticationProperties> GetProvider(ProviderRequest request)
        {
            try
            {
                return await _client.GetProvider(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        
        public async Task<bool> ExternalLogin()
        {
            try
            {
                await _client.ExternalLogin();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        #endregion

        #region Utilities

        private IList<Claim> ParseClaims(JwtSecurityToken token)
        {
            var claims = token.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, token.Subject));
            return claims;
        }

        #endregion

    }
}