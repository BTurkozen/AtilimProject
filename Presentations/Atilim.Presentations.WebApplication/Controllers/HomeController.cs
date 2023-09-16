using Atilim.Presentations.WebApplication.Models;
using Atilim.Presentations.WebApplication.Services.Interfaces;
using Atilim.Presentations.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Atilim.Presentations.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIdentityService _identityService;

        public HomeController(ILogger<HomeController> logger, IIdentityService identityService)
        {
            _logger = logger;
            _identityService = identityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Signin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(LoginViewModel loginViewModel)
        {

            var isLogin = await _identityService.SigninAsync(loginViewModel);

            if (isLogin)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}

