using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Commands.LessonCommands
{
    public class UpdateLessonCommand : IRequest<ResponseDto<NoContentDto>>
    {
        public UpdateLessonDto Lesson { get; set; }
        public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, ResponseDto<NoContentDto>>
        {
            private readonly ILessonService _lessonService;
            private readonly IMapper _mapper;

            public UpdateLessonCommandHandler(ILessonService lessonService, IMapper mapper)
            {
                _lessonService = lessonService ?? throw new ArgumentNullException(nameof(lessonService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<NoContentDto>> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
            {
                var lesson = _mapper.Map<Lesson>(request.Lesson);

                await _lessonService.UpdateAsync(lesson);

                return ResponseDto<NoContentDto>.Success(new NoContentDto(), System.Net.HttpStatusCode.NoContent);
            }
        }
    }
}
