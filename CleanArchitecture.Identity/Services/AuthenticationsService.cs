using CleanArchitecture.Identity.Models;

using CleanArichitecture.Application.Constants;
using CleanArichitecture.Application.Models.Idnetity;
using CleanArichitecture.Application.Persistence.ServiceContract.Identity;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Identity.Services
{
    public class AuthenticationsService : IAuthenticationsService
    {
        #region Fields

        private readonly UserManager<ApplicationUser> _userManager;        
        private readonly JwtSetting _jwtSetting;
        private readonly SignInManager<ApplicationUser> _signInManager;

        #endregion

        #region Ctor

        public AuthenticationsService(UserManager<ApplicationUser> userManager
            , IOptions<JwtSetting> jwtSetting
            , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSetting = jwtSetting.Value;
            _signInManager = signInManager;
        }

        #endregion

        #region Register
        
        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser != null)
                throw new Exception($"user name : {request.UserName} is already");

            var user = new ApplicationUser
            {
                Email = request.Email,
                EmailConfirmed = true,
                UserName = request.UserName,
                LastName = request.LastName,
                FirstName = request.FirstName
            };

            var exsitingEmail = await _userManager.FindByEmailAsync(user.Email);
            if (exsitingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Secretary");
                    return new RegistrationResponse { UserId = user.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
                throw new Exception($"Email '{request.Email}' already exists");
        }

        #endregion

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new Exception($"{request.Email} is not found");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!result.Succeeded)
                throw new Exception($"login for {user.UserName} faild");

            var jwtSecurityToken = await GenerateToken(user);
            var response = new AuthResponse
            {
                 Id = user.Id,
                 Email = user.Email,
                 UserName = user.UserName,
                 Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };

            return response;
        }


        public  AuthenticationProperties GetProvider(string provider ,string redirectUrl)
        {
            return  _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }


        public async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (var i = 0; i < roles.Count; i++)
                roleClaims.Add(new Claim(ClaimTypes.Role,roles[i]));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub , user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(CustomTypeClaim.UID , user.Id)
            }.Union(userClaims)
            .Union(roleClaims);

            var symmtericSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
            var signingCredential = new SigningCredentials(symmtericSecurity, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(audience: _jwtSetting.Audience,
                issuer: _jwtSetting.IsSure,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSetting.DurationInMinutes),
                signingCredentials: signingCredential);

            return jwtSecurityToken;
        }
       
    }
}