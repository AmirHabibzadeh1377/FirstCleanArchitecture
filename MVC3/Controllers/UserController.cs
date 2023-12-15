using CleanArichitecture.Application.Models.Idnetity;

using Microsoft.AspNetCore.Identity;
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

        #region Register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "model state is not valid");
                return View(model);
            }

            var isCreated = await _authenticationService.Register(model);
            if (!isCreated)
            {
                ModelState.AddModelError("", "faild to register please try again");
                return View(model);
            }

            return LocalRedirect("/");
        }

        #endregion

        #region Login

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

        #endregion

        #region LogOut

        public async Task<IActionResult> LogOut()
        {
            await _authenticationService.LogOut();
            return LocalRedirect("/User/Login");
        }


        #endregion
    }
}
