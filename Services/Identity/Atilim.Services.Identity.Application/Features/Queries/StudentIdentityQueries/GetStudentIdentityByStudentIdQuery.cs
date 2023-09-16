using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.StudentIdentityQueries
{
    public class GetStudentIdentityByStudentIdQuery : IRequest<ResponseDto<StudentIdentityDto>>
    {
        public int StudentId { get; set; }
        public class GetStudentIdentityByStudentIdQueryHandler : IRequestHandler<GetStudentIdentityByStudentIdQuery, ResponseDto<StudentIdentityDto>>
        {
            private readonly IStudentIdentityService _studentIdentityService;

            public GetStudentIdentityByStudentIdQueryHandler(IStudentIdentityService studentIdentityService)
            {
                _studentIdentityService = studentIdentityService ?? throw new ArgumentNullException(nameof(studentIdentityService));
            }

            public async Task<ResponseDto<StudentIdentityDto>> Handle(GetStudentIdentityByStudentIdQuery request, CancellationToken cancellationToken)
            {
                var studentIndetityDto = await _studentIdentityService.GetStudentIdentityByStudentId(request.StudentId);

                if (studentIndetityDto is not null)
                {
                    return ResponseDto<StudentIdentityDto>.Success(studentIndetityDto, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<StudentIdentityDto>.Fail($"{request.StudentId} Id'li öğrenci bulunamadı!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
