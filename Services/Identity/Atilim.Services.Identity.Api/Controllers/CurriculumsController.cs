using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Features.Commands.CurriculumCommands;
using Atilim.Services.Identity.Application.Features.Queries.CurriculumQueries;
using Atilim.Shared.CustomControllerBases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Services.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class CurriculumsController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public CurriculumsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("curriculums")]
        public async Task<IActionResult> GetAll()
        {
            return CustomActionResult(await _mediator.Send(new GetAllCurriculumQuery()));
        }

        [HttpGet("curriculum/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CustomActionResult(await _mediator.Send(new GetCurriculumByIdQuery() { Id = id }));
        }

        [HttpGet("curriculum-with-lessons")]
        public async Task<IActionResult> GetCurriculumWithLessons()
        {
            return CustomActionResult(await _mediator.Send(new GetAllCurriculumWithLessonsQuery()));
        }

        [HttpGet("curriculum-with-lessons-by-id/{id}")]
        public async Task<IActionResult> GetCurriculumWithLessonsById(int id)
        {
            return CustomActionResult(await _mediator.Send(new GetCurriculumWithLessonsByIdQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> InsertCurriculumWithLesson(CreateCurriculumWithLessonsDto curriculumWithLessonsDto)
        {
            return CustomActionResult(await _mediator.Send(new CreateCurriculumWithLessonsCommand() { Curriculum = curriculumWithLessonsDto }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCurriculumWithLesson(UpdateCurriculumWithLessonsDto updateCurriculumWithLessonsDto)
        {
            return CustomActionResult(await _mediator.Send(new UpdateCurriculumCommand() { UpdateCurriculum = updateCurriculumWithLessonsDto }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurriculumWithLesson(int id)
        {
            return CustomActionResult(await _mediator.Send(new DeleteCurriculumCommand() { Id = id }));
        }
    }
}
