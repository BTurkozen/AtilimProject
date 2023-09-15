using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.LessonQueries
{
    public class GetLessonByIdQuery : IRequest<ResponseDto<LessonDto>>
    {
        public int Id { get; set; }
        public class GetLessonByIdQueryHandler : IRequestHandler<GetLessonByIdQuery, ResponseDto<LessonDto>>
        {
            private readonly ILessonService _lessonService;

            public GetLessonByIdQueryHandler(ILessonService lessonService)
            {
                _lessonService = lessonService;
            }

            public async Task<ResponseDto<LessonDto>> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
            {
                var lesson = await _lessonService.GetLessonByIdAsync(request.Id);

                if (lesson is not null)
                {
                    return ResponseDto<LessonDto>.Success(lesson, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<LessonDto>.Fail($"{request.Id} Id'li ders bulunamadı!!!", System.Net.HttpStatusCode.NotFound);

            }
        }
    }
}
