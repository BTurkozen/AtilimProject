using Atilim.Services.Identity.Application.Features.Queries.StudentQueries;
using Atilim.Shared.CustomControllerBases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Services.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : CustomControllerBase
    {
        private readonly IMediator _medator;

        public StudentsController(IMediator medator)
        {
            _medator = medator;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAll()
        {
            return CustomActionResult(await _medator.Send(new GetAllStudentQuery()));
        }

        [HttpGet("{studentId}")]
        [Authorize(Roles = "admin,student")]
        public async Task<IActionResult> GetById(int studentId)
        {
            return CustomActionResult(await _medator.Send(new GetStudentByIdQuery() { StudentId = studentId }));
        }
    }
}
