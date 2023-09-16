using Atilim.Services.Identity.Application.Dtos.ContactInformationDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.ContactInformationQueries
{
    public class ContactInformationByStudentIdentityIdQuery : IRequest<ResponseDto<ContactInformationDto>>
    {
        public int StudentIdentityId { get; set; }
        public class ContactInformationByStudentIdentityIdQueryHandler : IRequestHandler<ContactInformationByStudentIdentityIdQuery, ResponseDto<ContactInformationDto>>
        {
            private readonly IContactInformationService _contactInformationService;

            public ContactInformationByStudentIdentityIdQueryHandler(IContactInformationService contactInformationService)
            {
                _contactInformationService = contactInformationService ?? throw new ArgumentNullException(nameof(contactInformationService));
            }

            public async Task<ResponseDto<ContactInformationDto>> Handle(ContactInformationByStudentIdentityIdQuery request, CancellationToken cancellationToken)
            {
                var studentIdentityDto = await _contactInformationService.GetContactInformationByStudentId(request.StudentIdentityId);

                if (studentIdentityDto is not null)
                {
                    return ResponseDto<ContactInformationDto>.Success(studentIdentityDto, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<ContactInformationDto>.Fail($"{request.StudentIdentityId} Id'li İletişim bilgilerine bulunamadı!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
