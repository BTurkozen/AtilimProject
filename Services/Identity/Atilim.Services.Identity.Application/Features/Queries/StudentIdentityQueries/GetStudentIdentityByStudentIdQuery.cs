using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.StudentIdentityQueries
{
    public class GetStudentIdentityByStudentIdQuery : IRequest<ResponseDto<StudentIdentityDto>>
    {
        public int StudentId { get; set; }
        public class GetStudentIdentityByStudentIdQueryHandler : IRequestHandler<GetStudentIdentityByStudentIdQuery, ResponseDto<StudentIdentityDto>>
        {
            private readonly IStudentIdentityService _studentIdentityService;
            private readonly IMapper _mapper;
            public GetStudentIdentityByStudentIdQueryHandler(IStudentIdentityService studentIdentityService, IMapper mapper)
            {
                _studentIdentityService = studentIdentityService ?? throw new ArgumentNullException(nameof(studentIdentityService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<StudentIdentityDto>> Handle(GetStudentIdentityByStudentIdQuery request, CancellationToken cancellationToken)
            {
                var studentIndetity = await _studentIdentityService.GetStudentIdentityByStudentId(request.StudentId);

                if (studentIndetity is not null)
                {
                    var studentIndetityDto = _mapper.Map<StudentIdentityDto>(studentIndetity);

                    return ResponseDto<StudentIdentityDto>.Success(studentIndetityDto, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<StudentIdentityDto>.Fail($"{request.StudentId} Id'li öğrenci bulunamadı!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
