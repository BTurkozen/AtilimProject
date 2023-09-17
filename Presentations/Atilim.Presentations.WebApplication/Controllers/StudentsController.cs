using Atilim.Presentations.WebApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Presentations.WebApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAsync();

            return View(students);
        }

        public async Task<IActionResult> GetStudentOtherInfosById(int studentId)
        {
            var student = await _studentService.GetByIdAsync(studentId);

            return PartialView(student);
        }
    }
}
