using Atilim.Presentations.WebApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Presentations.WebApplication.Controllers
{
    [Authorize]
    public class CurriculumsController : Controller
    {
        private readonly ICurriculumService _curriculumService;

        public CurriculumsController(ICurriculumService curriculumService)
        {
            _curriculumService = curriculumService;
        }

        public async Task<IActionResult> Index()
        {
            var curriculums = await _curriculumService.GetAllAsync();

            return View(curriculums);
        }
    }
}
