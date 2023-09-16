using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.CurriculumQueries
{
    public class GetAllCurriculumWithLessonsQuery : IRequest<ResponseDto<List<CurriculumWithLessonsDto>>>
    {
        public class GetAllCurriculumWithLessonsQueryHandler : IRequestHandler<GetAllCurriculumWithLessonsQuery, ResponseDto<List<CurriculumWithLessonsDto>>>
        {
            private readonly ICurriculumService _curriculumService;

            public GetAllCurriculumWithLessonsQueryHandler(ICurriculumService curriculumService)
            {
                _curriculumService = curriculumService ?? throw new ArgumentNullException(nameof(curriculumService));
            }

            public async Task<ResponseDto<List<CurriculumWithLessonsDto>>> Handle(GetAllCurriculumWithLessonsQuery request, CancellationToken cancellationToken)
            {
                var curriculumWithLessonsDtos = await _curriculumService.GetAllCurriculumWithLessonsAsync();

                if (curriculumWithLessonsDtos.Count > 0)
                {

                    return ResponseDto<List<CurriculumWithLessonsDto>>.Success(curriculumWithLessonsDtos, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<List<CurriculumWithLessonsDto>>.Fail("Müfredatlar bulunamadı!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
