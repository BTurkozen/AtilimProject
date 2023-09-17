using Atilim.Services.Identity.Application.Dtos.ContactInformationDtos;
using Atilim.Services.Identity.Application.Features.Commands.ContactInformationCommands;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var queryModel = new ContactInformationByStudentIdentityIdQuery()
            {
                Id = id
            };

            return CustomActionResult(await _mediator.Send(queryModel));
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateContactInformation(UpdateContactInformationDto updateContactInformationDto)
        {
            var commandModel = new UpdateContactInformationCommand() { ContactInformation = updateContactInformationDto };

            return CustomActionResult(await _mediator.Send(commandModel));
        }
    }
}
