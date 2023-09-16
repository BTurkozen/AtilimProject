using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.CurriculumQueries
{
    public class GetCurriculumWithLessonsByIdQuery : IRequest<ResponseDto<CurriculumWithLessonsDto>>
    {
        public int Id { get; set; }

        public class GetCurriculumWithLessonsByIdQueryHandler : IRequestHandler<GetCurriculumWithLessonsByIdQuery, ResponseDto<CurriculumWithLessonsDto>>
        {
            private readonly ICurriculumService _curriculumService;
            private readonly IMapper _mapper;

            public GetCurriculumWithLessonsByIdQueryHandler(ICurriculumService curriculumService, IMapper mapper)
            {
                _curriculumService = curriculumService ?? throw new ArgumentNullException(nameof(curriculumService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<CurriculumWithLessonsDto>> Handle(GetCurriculumWithLessonsByIdQuery request, CancellationToken cancellationToken)
            {
                var curriculumWithLessons = await _curriculumService.GetCurriculumWithLessonsByIdAsync(request.Id);

                if (curriculumWithLessons is not null)
                {
                    var curriculumWithLessonsDto = _mapper.Map<CurriculumWithLessonsDto>(curriculumWithLessons);

                    return ResponseDto<CurriculumWithLessonsDto>.Success(curriculumWithLessonsDto, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<CurriculumWithLessonsDto>.Fail($"{request.Id} Id'li müfredat bulunamadı!!!", System.Net.HttpStatusCode.NotFound);

            }
        }
    }
}
