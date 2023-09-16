using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Commands.LessonCommands
{
    public class CreateLessonCommand : IRequest<ResponseDto<int>>
    {
        public CreateLessonDto CreateLesson { get; set; }

        public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, ResponseDto<int>>
        {
            private readonly ILessonService _lessonService;
            private readonly IMapper _mapper;

            public CreateLessonCommandHandler(ILessonService lessonService, IMapper mapper)
            {
                _lessonService = lessonService ?? throw new ArgumentNullException(nameof(lessonService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<int>> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
            {
                var lesson = _mapper.Map<Lesson>(request.CreateLesson);

                if (lesson is null)
                {
                    return ResponseDto<int>.Fail("Model boş!!!", System.Net.HttpStatusCode.BadRequest);
                }

                return ResponseDto<int>.Success(await _lessonService.InsertAsync(lesson), System.Net.HttpStatusCode.Created);
            }
        }
    }
}
