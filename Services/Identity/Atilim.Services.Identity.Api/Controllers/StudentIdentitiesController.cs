using Atilim.Services.Identity.Application.Features.Queries.StudentIdentityQueries;
using Atilim.Shared.CustomControllerBases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Services.Identity.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StudentIdentitiesController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public StudentIdentitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var queryModel = new GetStudentIdentityByIdQuery() { Id = id };

            return CustomActionResult(await _mediator.Send(queryModel));
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            var queryModel = new GetStudentIdentityByStudentIdQuery() { StudentId = studentId };

            return CustomActionResult(await _mediator.Send(queryModel));
        }

    }
}
