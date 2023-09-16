using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Commands.LessonCommands
{
    public class DeleteLessonCommand : IRequest<ResponseDto<NoContentDto>>
    {
        public int Id { get; set; }
        public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, ResponseDto<NoContentDto>>
        {
            private readonly ILessonService _lessonService;

            public DeleteLessonCommandHandler(ILessonService lessonService)
            {
                _lessonService = lessonService;
            }

            public async Task<ResponseDto<NoContentDto>> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
            {
                var hasDeleted = await _lessonService.DeleteAsync(request.Id);

                if (hasDeleted)
                {
                    return ResponseDto<NoContentDto>.Success(new NoContentDto(), System.Net.HttpStatusCode.NoContent);
                }

                return ResponseDto<NoContentDto>.Fail($"{request.Id} Id'li ders silinme işlemi gerçekleştirilemedi!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
