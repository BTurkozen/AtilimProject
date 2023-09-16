 using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.StudentQueries
{
    public class GetAllStudentQuery : IRequest<ResponseDto<List<StudentDto>>>
    {
        public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, ResponseDto<List<StudentDto>>>
        {
            private readonly IStudentService _studentService;
            private readonly IMapper _mapper;
            public GetAllStudentQueryHandler(IStudentService studentService, IMapper mapper)
            {
                _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<List<StudentDto>>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
            {
                var students = await _studentService.GetAllStudentAsync();

                if (students.Count > 0)
                {
                    var studentDtos = _mapper.Map<List<StudentDto>>(students);

                    return ResponseDto<List<StudentDto>>.Success(studentDtos, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<List<StudentDto>>.Fail("Öğrencileri çekerken bir problem oluştu!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
