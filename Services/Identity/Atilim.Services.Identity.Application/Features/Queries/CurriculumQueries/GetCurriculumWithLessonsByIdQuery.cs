using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.CurriculumQueries
{
    public class GetCurriculumWithLessonsByIdQuery : IRequest<ResponseDto<CurriculumWithLessonsDto>>
    {
        public int Id { get; set; }

        public class GetCurriculumWithLessonsByIdQueryHandler : IRequestHandler<GetCurriculumWithLessonsByIdQuery, ResponseDto<CurriculumWithLessonsDto>>
        {
            private readonly ICurriculumService _curriculumService;

            public GetCurriculumWithLessonsByIdQueryHandler(ICurriculumService curriculumService)
            {
                _curriculumService = curriculumService ?? throw new ArgumentNullException(nameof(curriculumService));
            }

            public async Task<ResponseDto<CurriculumWithLessonsDto>> Handle(GetCurriculumWithLessonsByIdQuery request, CancellationToken cancellationToken)
            {
                var curriculumWithLessonsDto = await _curriculumService.GetCurriculumWithLessonsByIdAsync(request.Id);

                if (curriculumWithLessonsDto is not null)
                {
                    return ResponseDto<CurriculumWithLessonsDto>.Success(curriculumWithLessonsDto, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<CurriculumWithLessonsDto>.Fail($"{request.Id} Id'li müfredat bulunamadı!!!", System.Net.HttpStatusCode.NotFound);

            }
        }
    }
}
