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
                _lessonService = lessonService ?? throw new ArgumentNullException(nameof(lessonService));
            }

            public async Task<ResponseDto<List<LessonDto>>> Handle(GetAllLessonQuery request, CancellationToken cancellationToken)
            {
                var lessons = await _lessonService.GetAllLessonAsync();

                var lessonDtos = lessons.Select(l => new LessonDto
                {
                    Id = l.Id,
                    Credit = l.Credit,
                    IsDeleted = l.IsDeleted,
                    LessonCode = l.LessonCode,
                    LessonName = l.LessonName,
                    Status = l.Status,
                }).ToList();

                if (lessonDtos.Count > 0)
                {
                    return ResponseDto<List<LessonDto>>.Success(lessonDtos, HttpStatusCode.OK);
                }

                return ResponseDto<List<LessonDto>>.Fail("Dersler Bulunamadı!!!", HttpStatusCode.NotFound);
            }
        }
    }
}
