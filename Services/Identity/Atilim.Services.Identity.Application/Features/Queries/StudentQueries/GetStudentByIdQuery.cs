using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.StudentQueries
{
    public class GetStudentByIdQuery : IRequest<ResponseDto<StudentDto>>
    {
        public int StudentId { get; set; }

        public class StudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, ResponseDto<StudentDto>>
        {
            private readonly IStudentService _studentService;

            public StudentByIdQueryHandler(IStudentService studentService)
            {
                _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            }

            public async Task<ResponseDto<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
            {
                var studentDto = await _studentService.GetStudentByIdAsycn(request.StudentId);

                if (studentDto is not null)
                {
                    return ResponseDto<StudentDto>.Success(studentDto, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<StudentDto>.Fail($"{request.StudentId} Id'li Öğrenci bulunamadı!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
