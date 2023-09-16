﻿using Atilim.Services.Identity.Application.Dtos.ContactInformationDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.ContactInformationQueries
{
    public class ContactInformationByStudentIdentityIdQuery : IRequest<ResponseDto<ContactInformationDto>>
    {
        public int StudentIdentityId { get; set; }
        public class ContactInformationByStudentIdentityIdQueryHandler : IRequestHandler<ContactInformationByStudentIdentityIdQuery, ResponseDto<ContactInformationDto>>
        {
            private readonly IContactInformationService _contactInformationService;
            private readonly IMapper _mapper;

            public ContactInformationByStudentIdentityIdQueryHandler(IContactInformationService contactInformationService, IMapper mapper)
            {
                _contactInformationService = contactInformationService ?? throw new ArgumentNullException(nameof(contactInformationService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<ContactInformationDto>> Handle(ContactInformationByStudentIdentityIdQuery request, CancellationToken cancellationToken)
            {
                var contactInformation = await _contactInformationService.GetContactInformationByStudentId(request.StudentIdentityId);

                if (contactInformation is not null)
                {
                    var contactIdentityDto = _mapper.Map<ContactInformationDto>(contactInformation);

                    return ResponseDto<ContactInformationDto>.Success(contactIdentityDto, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<ContactInformationDto>.Fail($"{request.StudentIdentityId} Id'li İletişim bilgilerine bulunamadı!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
