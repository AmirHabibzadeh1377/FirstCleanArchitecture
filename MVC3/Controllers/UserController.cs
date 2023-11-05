using Microsoft.AspNetCore.Mvc;

using MVC3.Contract;
using MVC3.Model.ViewModels.UserAccount;

namespace MVC3.Controllers
{
    public class UserController : Controller
    {
        #region Fields

        private readonly IAuthenticationsServiceContract _authenticationService;

        #endregion

        #region Ctor

        public UserController(IAuthenticationsServiceContract authenticationService)
        {
            _authenticationService = authenticationService;
        }

        #endregion
        public IActionResult Login(string? returnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login, string? returnUrl)
        {
            returnUrl ??= Url.Content("/");
            var isLoggedIn = await _authenticationService.Authentication(login.Email, login.Password);
            if (isLoggedIn)
            {
                return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError("", "login faild please try again");
            return View(login);
        }
    }
}
