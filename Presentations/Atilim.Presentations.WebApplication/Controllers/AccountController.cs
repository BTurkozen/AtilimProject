using Atilim.Presentations.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Presentations.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            return View();
        }
    }
}
