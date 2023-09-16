using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.LessonQueries
{
    public class GetLessonByIdQuery : IRequest<ResponseDto<LessonDto>>
    {
        public int Id { get; set; }
        public class GetLessonByIdQueryHandler : IRequestHandler<GetLessonByIdQuery, ResponseDto<LessonDto>>
        {
            private readonly ILessonService _lessonService;
            private readonly IMapper _mapper;

            public GetLessonByIdQueryHandler(ILessonService lessonService)
            {
                _lessonService = lessonService ?? throw new ArgumentNullException(nameof(lessonService));
            }

            public async Task<ResponseDto<LessonDto>> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
            {
                var lesson = await _lessonService.GetLessonByIdAsync(request.Id);

                if (lesson is not null)
                {
                    var lessonDto = _mapper.Map<LessonDto>(lesson);

                    return ResponseDto<LessonDto>.Success(lessonDto, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<LessonDto>.Fail($"{request.Id} Id'li ders bulunamadı!!!", System.Net.HttpStatusCode.NotFound);

            }
        }
    }
}
