using Atilim.Services.Identity.Application.Dtos.ContactInformationDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Commands.ContactInformationCommands
{
    public class UpdateContactInformationCommand : IRequest<ResponseDto<NoContentDto>>
    {
        public UpdateContactInformationDto ContactInformation { get; set; }

        public class UpdateContactInformationCommandHandler : IRequestHandler<UpdateContactInformationCommand, ResponseDto<NoContentDto>>
        {
            private readonly IContactInformationService _contactInformationService;

            public UpdateContactInformationCommandHandler(IContactInformationService contactInformationService)
            {
                _contactInformationService = contactInformationService;
            }

            public async Task<ResponseDto<NoContentDto>> Handle(UpdateContactInformationCommand request, CancellationToken cancellationToken)
            {
                var contactInformation = new ContactInformation()
                {
                    Address = request.ContactInformation.Address,
                    City = request.ContactInformation.City,
                    Country = request.ContactInformation.Country,
                    District = request.ContactInformation.District,
                    Email = request.ContactInformation.Email,
                    Id = request.ContactInformation.Id,
                    MobilePhoneNumber = request.ContactInformation.MobilePhoneNumber,
                    StudentIdentityId = request.ContactInformation.StudentIdentityId,
                };

                var hasUpdateContactInformation = await _contactInformationService.UpdateAsync(contactInformation);

                if (hasUpdateContactInformation)
                {
                    return ResponseDto<NoContentDto>.Success(new NoContentDto(), System.Net.HttpStatusCode.NoContent);
                }

                return ResponseDto<NoContentDto>.Fail("Öğrenci İletişim Bilgileri Güncelleme işlemi gerçekleştirilemedi!!!", System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
