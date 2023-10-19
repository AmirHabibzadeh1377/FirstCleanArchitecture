using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MVC.Controllers
{
    public class WeblogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
