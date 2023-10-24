using AutoMapper;
using CleanArchitecture.MVC3.Contract;
using CleanArchitecture.MVC3.Model.ViewModels.Weblog;
using CleanArichitecture.Application.DTOs.Weblog;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MVC.Controllers
{
    public class WeblogController : Controller
    {
        #region Fields

        private readonly IWeblogServiceContract _weblogService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public WeblogController(IWeblogServiceContract weblogService, IMapper mapper)
        {
            _weblogService = weblogService;
            _mapper = mapper;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            var weblogs = await _weblogService.GetAllWeblogList();
            var weblogListVM = _mapper.Map<List<WeblogListVM>>(weblogs);
            return View(weblogListVM);
        }

        [HttpGet]
        public async Task<IActionResult> CreateWeblog()
        {
            return View(new CreateWeblogVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWeblog(CreateWeblogVM model)
        {
            try
            {
                var result = await _weblogService.CreateWeblog(model);
                if (!result.Success)
                {
                    ModelState.AddModelError("error code is :", result.ValidationError);
                }
                else
                {
                    RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> EditWeblog(int weblogId)
        {
            var weblogListVM = await _weblogService.GetWeblogById(weblogId);
            var weblogUpdateVM = _mapper.Map<UpdateWeblogVM>(weblogListVM);
            return View(weblogUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWeblog(UpdateWeblogVM model)
        {
            try
            {
                var result = await _weblogService.UpdateWeblog(model);
                if (!result.Success)
                {
                    ModelState.AddModelError("error  is :", result.ValidationError);
                }
                else
                {
                    RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }
    }
}
