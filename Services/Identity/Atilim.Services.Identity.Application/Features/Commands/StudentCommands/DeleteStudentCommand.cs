using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Commands.StudentCommands
{
    public class DeleteStudentCommand : IRequest<ResponseDto<NoContentDto>>
    {
        public DeleteStudentDto Student { get; set; }

        public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, ResponseDto<NoContentDto>>
        {
            private readonly IStudentService _studentService;

            public DeleteStudentCommandHandler(IStudentService studentService)
            {
                _studentService = studentService;
            }

            public async Task<ResponseDto<NoContentDto>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
            {
                var hasDeletedStudent = await _studentService.DeleteAsync(request.Student.Id);

                if (hasDeletedStudent)
                {
                    return ResponseDto<NoContentDto>.Success(new NoContentDto(), System.Net.HttpStatusCode.NoContent);
                }

                return ResponseDto<NoContentDto>.Fail("", System.Net.HttpStatusCode.BadRequest);

            }
        }
    }
}
