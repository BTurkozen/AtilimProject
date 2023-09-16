using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;
using System.Net;

namespace Atilim.Services.Identity.Application.Features.Queries.LessonQueries
{
    public class GetAllLessonQuery : IRequest<ResponseDto<List<LessonDto>>>
    {
        public class GetAllLessonQueryHandler : IRequestHandler<GetAllLessonQuery, ResponseDto<List<LessonDto>>>
        {
            private readonly ILessonService _lessonService;
            private readonly IMapper _mapper;

            public GetAllLessonQueryHandler(ILessonService lessonService, IMapper mapper)
            {
                _lessonService = lessonService ?? throw new ArgumentNullException(nameof(lessonService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<List<LessonDto>>> Handle(GetAllLessonQuery request, CancellationToken cancellationToken)
            {
                var lessons = await _lessonService.GetAllLessonAsync();

                if (lessons.Count > 0)
                {
                    var lessonDtos = _mapper.Map<List<LessonDto>>(lessons);

                    return ResponseDto<List<LessonDto>>.Success(lessonDtos, HttpStatusCode.OK);
                }

                return ResponseDto<List<LessonDto>>.Fail("Dersler Bulunamadı!!!", HttpStatusCode.NotFound);
            }
        }
    }
}
