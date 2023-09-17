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
    public class GetStudentByIdQuery : IRequest<ResponseDto<StudentDto>>
    {
        public int StudentId { get; set; }

        public class StudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, ResponseDto<StudentDto>>
        {
            private readonly IStudentService _studentService;
            private readonly IMapper _mapper;

            public StudentByIdQueryHandler(IStudentService studentService, IMapper mapper)
            {
                _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
            {
                var student = await _studentService.GetStudentByIdAsync(request.StudentId);

                if (student is not null)
                {
                    var studentDto = new StudentDto
                    {
                        Id = student.Id,
                        StudentNo = student.StudentNo,
                        FullName = $"{student.StudentIdentity.Name} {student.StudentIdentity.Surname}",
                        IsDeleted = student.IsDeleted,
                        Curriculum = new CurriculumDto
                        {
                            Id = student.Curriculum.Id,
                            CurriculumName = student.Curriculum.CurriculumName,
                            IsDeleted = student.Curriculum.IsDeleted,
                            CurriculumLessons = student.Curriculum.CurriculumLessons.Select(cl => new CurriculumLessonDto
                            {
                                Lesson = new LessonDto
                                {
                                    Id = cl.Lesson.Id,
                                    Credit = cl.Lesson.Credit,
                                    LessonCode = cl.Lesson.LessonCode,
                                    LessonName = cl.Lesson.LessonName,
                                    Status = cl.Lesson.Status,
                                }
                            }).ToList()
                        },
                        StudentIdentity = new StudentIdentityDto()
                        {
                            Id = student.StudentIdentity.Id,
                            CityOfBirth = student.StudentIdentity.CityOfBirth,
                            DateOfBirth = student.StudentIdentity.DateOfBirth,
                            IsDeleted = student.StudentIdentity.IsDeleted,
                            Name = student.StudentIdentity.Name,
                            Surname = student.StudentIdentity.Surname,
                            TCIdentificationNo = student.StudentIdentity.TCIdentificationNo,
                        },
                        ContactInformation = new ContactInformationDto()
                        {
                            Id = student.StudentIdentity.ContactInformation.Id,
                            IsDeleted = student.StudentIdentity.ContactInformation.IsDeleted,
                            Address = student.StudentIdentity.ContactInformation.Address,
                            City = student.StudentIdentity.ContactInformation.City,
                            Country = student.StudentIdentity.ContactInformation.Country,
                            District = student.StudentIdentity.ContactInformation.District,
                            Email = student.StudentIdentity.ContactInformation.Email,
                            MobilePhoneNumber = student.StudentIdentity.ContactInformation.MobilePhoneNumber
                        }
                    };

                    return ResponseDto<StudentDto>.Success(studentDto, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<StudentDto>.Fail($"{request.StudentId} Id'li Öğrenci bulunamadı!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
