using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.StudentIdentityQueries
{
    public class GetStudentIdentityByIdQuery : IRequest<ResponseDto<StudentIdentityDto>>
    {
        public int Id { get; set; }

        public class GetStudentIdentityByIdQueryHandler : IRequestHandler<GetStudentIdentityByIdQuery, ResponseDto<StudentIdentityDto>>
        {
            private readonly IStudentIdentityService _studentIdentityService;
            private readonly IMapper _mapper;

            public GetStudentIdentityByIdQueryHandler(IStudentIdentityService studentIdentityService, IMapper mapper)
            {
                _studentIdentityService = studentIdentityService ?? throw new ArgumentNullException(nameof(studentIdentityService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<StudentIdentityDto>> Handle(GetStudentIdentityByIdQuery request, CancellationToken cancellationToken)
            {
                var studentIndetity = await _studentIdentityService.GetStudentIdentityById(request.Id);

                if (studentIndetity is not null)
                {
                    var studentIndetityDto = _mapper.Map<StudentIdentityDto>(studentIndetity);

                    return ResponseDto<StudentIdentityDto>.Success(studentIndetityDto, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<StudentIdentityDto>.Fail($"{request.Id} Id'li öğrenci kimlik bilgileri bulunamadı!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
