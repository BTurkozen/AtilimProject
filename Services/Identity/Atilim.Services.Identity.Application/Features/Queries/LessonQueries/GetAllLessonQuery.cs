using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;
using System.Net;

namespace Atilim.Services.Identity.Application.Features.Queries.LessonQueries
{
    public class GetAllLessonQuery : IRequest<ResponseDto<List<LessonDto>>>
    {
        public class GetAllLessonQueryHandler : IRequestHandler<GetAllLessonQuery, ResponseDto<List<LessonDto>>>
        {
            private readonly ILessonService _lessonService;

            public GetAllLessonQueryHandler(ILessonService lessonService)
            {
                _lessonService = lessonService;
            }

            public async Task<ResponseDto<List<LessonDto>>> Handle(GetAllLessonQuery request, CancellationToken cancellationToken)
            {
                var lessons = await _lessonService.GetAllLessonAsync();

                if (lessons.Count > 0)
                {
                    return ResponseDto<List<LessonDto>>.Success(lessons, HttpStatusCode.OK);
                }

                return ResponseDto<List<LessonDto>>.Fail("Dersler Bulunamadı!!!", HttpStatusCode.NotFound);
            }
        }
    }
}
