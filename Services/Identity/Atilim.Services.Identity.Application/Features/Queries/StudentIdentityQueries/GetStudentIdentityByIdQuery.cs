using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.StudentIdentityQueries
{
    public class GetStudentIdentityByIdQuery : IRequest<ResponseDto<StudentIdentityDto>>
    {
        public int Id { get; set; }

        public class GetStudentIdentityByIdQueryHandler : IRequestHandler<GetStudentIdentityByIdQuery, ResponseDto<StudentIdentityDto>>
        {
            private readonly IStudentIdentityService _studentIdentityService;

            public GetStudentIdentityByIdQueryHandler(IStudentIdentityService studentIdentityService)
            {
                _studentIdentityService = studentIdentityService ?? throw new ArgumentNullException(nameof(studentIdentityService));
            }

            public async Task<ResponseDto<StudentIdentityDto>> Handle(GetStudentIdentityByIdQuery request, CancellationToken cancellationToken)
            {
                var studentIndetityDto = await _studentIdentityService.GetStudentIdentityById(request.Id);

                if (studentIndetityDto is not null)
                {
                    return ResponseDto<StudentIdentityDto>.Success(studentIndetityDto, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<StudentIdentityDto>.Fail($"{request.Id} Id'li öğrenci kimlik bilgileri bulunamadı!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
