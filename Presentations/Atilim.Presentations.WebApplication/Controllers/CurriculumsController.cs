using Atilim.Presentations.WebApplication.Services.Interfaces;
using Atilim.Presentations.WebApplication.ViewModels.CurriculumViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Presentations.WebApplication.Controllers
{
    [Authorize]
    public class CurriculumsController : Controller
    {
        private readonly ICurriculumService _curriculumService;
        private readonly ILessonService _lessonService;

        public CurriculumsController(ICurriculumService curriculumService, ILessonService lessonService)
        {
            _curriculumService = curriculumService;
            _lessonService = lessonService;
        }

        public async Task<IActionResult> Index()
        {
            var curriculums = await _curriculumService.GetCurriculumWithLessonsAsync();

            return View(curriculums);
        }

        public async Task<IActionResult> GetLessonsByCurriculumId(int curriculumId)
        {
            var result = await _curriculumService.GetCurriculumWithLessonsByIdAsync(curriculumId);

            return PartialView(result);
        }


        public async Task<IActionResult> Insert()
        {
            var result = new CurriculumWithLessonViewModel()
            {
                Lessons = await _lessonService.GetAll(),
            };

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CurriculumWithLessonViewModel curriculumWithLessonViewModel)
        {
            var lessons = await _lessonService.GetAll();

            curriculumWithLessonViewModel.Lessons = lessons.Where(l => curriculumWithLessonViewModel.SelectedLessons.Contains(l.Id)).ToList();

            var result = await _curriculumService.InsertAsync(curriculumWithLessonViewModel);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _curriculumService.GetByIdAsync(id);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CurriculumViewModel curriculumViewModel)
        {
            var result = await _curriculumService.UpdateAsync(curriculumViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _curriculumService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
