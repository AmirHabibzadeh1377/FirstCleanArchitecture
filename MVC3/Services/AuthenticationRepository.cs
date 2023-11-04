using CleanArchitecture.MVC3;
using CleanArchitecture.MVC3.Services.Base;
using MVC3.Contract;
using MVC3.Model;
using System.IdentityModel.Tokens.Jwt;

namespace MVC3.Services
{
    public class AuthenticationRepository : BaseHttpResponse, IAuthenticationsServiceContract
    {
        #region Fields

        private readonly IHttpContextAccessor _contextAccessor;
        JwtSecurityTokenHandler jwtSecurityTokenHandler;

        #endregion

        #region Ctor

        public AuthenticationRepository(IHttpContextAccessor contextAccessor, IClient client, ILocalStorageServiceContract localStorageService)
            :base(localStorageService,client)
        {
            _contextAccessor = contextAccessor;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        #endregion

        public Task<bool> Authentication(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task LogOut()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}