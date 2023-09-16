using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.StudentQueries
{
    public class GetAllStudentQuery : IRequest<ResponseDto<List<StudentDto>>>
    {
        public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, ResponseDto<List<StudentDto>>>
        {
            private readonly IStudentService _studentService;

            public GetAllStudentQueryHandler(IStudentService studentService)
            {
                _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            }

            public async Task<ResponseDto<List<StudentDto>>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
            {
                var studentDtos = await _studentService.GetAllStudentAsync();

                if (studentDtos.Count > 0)
                {
                    return ResponseDto<List<StudentDto>>.Success(studentDtos, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<List<StudentDto>>.Fail("Öğrencileri çekerken bir problem oluştu!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
