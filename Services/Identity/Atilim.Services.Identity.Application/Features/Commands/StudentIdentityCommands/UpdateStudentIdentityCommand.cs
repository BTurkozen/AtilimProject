using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Commands.StudentIdentityCommands
{
    public class UpdateStudentIdentityCommand : IRequest<ResponseDto<NoContentDto>>
    {
        public UpdateStudentIdentityDto StudentIdentity { get; set; }
        public class UpdateStudentIdentityCommandHandler : IRequestHandler<UpdateStudentIdentityCommand, ResponseDto<NoContentDto>>
        {
            private readonly IStudentIdentityService _studentIdentityService;
            private readonly IMapper _mapper;

            public UpdateStudentIdentityCommandHandler(IStudentIdentityService studentIdentityService, IMapper mapper)
            {
                _studentIdentityService = studentIdentityService;
                _mapper = mapper;
            }

            public async Task<ResponseDto<NoContentDto>> Handle(UpdateStudentIdentityCommand request, CancellationToken cancellationToken)
            {
                var studentIdentity = new StudentIdentity()
                {
                    CityOfBirth = request.StudentIdentity.CityOfBirth,
                    DateOfBirth = request.StudentIdentity.DateOfBirth,
                    TCIdentificationNo = request.StudentIdentity.TCIdentificationNo,
                    Name = request.StudentIdentity.Name,
                    Surname = request.StudentIdentity.Surname,
                    Id = request.StudentIdentity.Id,
                };

                var hasUpdated = await _studentIdentityService.UpdateAsync(studentIdentity);

                if (hasUpdated)
                {
                    return ResponseDto<NoContentDto>.Success(new NoContentDto(), System.Net.HttpStatusCode.NoContent);
                }

                return ResponseDto<NoContentDto>.Fail("Öğrenci kimlik bilgileri güncelleme işllemi gerçekleştirilemedi!!!", System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
