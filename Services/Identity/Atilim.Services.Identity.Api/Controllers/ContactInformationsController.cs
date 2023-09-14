using Atilim.Services.Identity.Application.Features.Queries.ContactInformationQueries;
using Atilim.Shared.CustomControllerBases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Services.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactInformationsController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public ContactInformationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{studentIdentityId}")]
        public async Task<IActionResult> GetByStudentIdentityId(int studentIdentityId)
        {
            var queryModel = new ContactInformationByStudentIdentityIdQuery()
            {
                StudentIdentityId = studentIdentityId
            };

            return CustomActionResult(await _mediator.Send(queryModel));
        }
    }
}
