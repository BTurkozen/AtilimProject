using Atilim.Services.Identity.Application.Dtos.ContactInformationDtos;
using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;
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
                    var studentDtos = students.Select(s => new StudentDto
                    {
                        Id = s.Id,
                        StudentNo = s.StudentNo,
                        FullName = $"{s.StudentIdentity.Name} {s.StudentIdentity.Name}",
                        IsDeleted = s.IsDeleted,
                        Curriculum = new CurriculumDto
                        {
                            Id = s.Curriculum.Id,
                            CurriculumName = s.Curriculum.CurriculumName,
                        }
                    }).ToList();

                    return ResponseDto<List<StudentDto>>.Success(studentDtos, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<List<StudentDto>>.Fail("Öğrencileri çekerken bir problem oluştu!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
