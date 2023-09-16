using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Presentations.WebApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class AccountController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}