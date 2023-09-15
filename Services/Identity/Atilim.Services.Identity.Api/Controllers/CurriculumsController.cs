using Atilim.Services.Identity.Application.Features.Queries.CurriculumQueries;
using Atilim.Shared.CustomControllerBases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Services.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurriculumsController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public CurriculumsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAll() => CustomActionResult(await _mediator.Send(new GetAllCurriculumQuery()));

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,student")]
        public async Task<IActionResult> GetById(int id) => CustomActionResult(await _mediator.Send(new GetCurriculumByIdQuery() { Id = id }));
    }
}
