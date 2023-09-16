using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Commands.StudentCommands
{
    public class UpdateStudentCommand : IRequest<ResponseDto<NoContentDto>>
    {
        public UpdateStudentDto Student { get; set; }
        public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, ResponseDto<NoContentDto>>
        {
            private readonly IStudentService _studentService;
            private readonly IMapper _mapper;

            public UpdateStudentCommandHandler(IStudentService studentService, IMapper mapper)
            {
                _studentService = studentService;
                _mapper = mapper;
            }

            public async Task<ResponseDto<NoContentDto>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
            {
                var student = _mapper.Map<Student>(request.Student);

                var hasUpdatedstudent = await _studentService.UpdateAsync(student);

                if (hasUpdatedstudent)
                {
                    return ResponseDto<NoContentDto>.Success(new NoContentDto(), System.Net.HttpStatusCode.NoContent);
                }

                return ResponseDto<NoContentDto>.Fail("Öğrenci Güncelleme işlemi gerçekleştirilemedi!!!", System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
