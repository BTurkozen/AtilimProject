using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Commands.StudentCommands
{
    public class CreateStudentCommand : IRequest<ResponseDto<int>>
    {
        public CreateStudentDto Student { get; set; }
        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, ResponseDto<int>>
        {
            private readonly IStudentService _studentService;
            private readonly IMapper _mapper;

            public CreateStudentCommandHandler(IStudentService studentService, IMapper mapper)
            {
                _studentService = studentService;
                _mapper = mapper;
            }

            public async Task<ResponseDto<int>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {
                var student = _mapper.Map<Student>(request.Student);

                if (student is null)
                {
                    return ResponseDto<int>.Fail("Model boş!!!", System.Net.HttpStatusCode.BadRequest);
                }

                return ResponseDto<int>.Success(await _studentService.InsertAsync(student), System.Net.HttpStatusCode.Created);
            }
        }
    }
}
