using Atilim.Services.Identity.Application.Features.Queries.LessonQueries;
using Atilim.Shared.CustomControllerBases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Services.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LessonsController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public LessonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => CustomActionResult(await _mediator.Send(new GetAllLessonQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => CustomActionResult(await _mediator.Send(new GetLessonByIdQuery() { Id = id }));
    }
}
