using Atilim.Services.Identity.Application.Features.Queries.StudentQueries;
using Atilim.Shared.CustomControllerBases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Services.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : CustomControllerBase
    {
        private readonly IMediator _medator;

        public StudentsController(IMediator medator)
        {
            _medator = medator;
        }

        public async Task<IActionResult> GetAllStudent()
        {
            return CustomActionResult(await _medator.Send(new GetAllStudentQuery()));
        }
    }
}
