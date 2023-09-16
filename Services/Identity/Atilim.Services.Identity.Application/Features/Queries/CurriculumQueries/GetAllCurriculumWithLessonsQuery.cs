using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.CurriculumQueries
{
    public class GetAllCurriculumWithLessonsQuery : IRequest<ResponseDto<List<CurriculumWithLessonsDto>>>
    {
        public class GetAllCurriculumWithLessonsQueryHandler : IRequestHandler<GetAllCurriculumWithLessonsQuery, ResponseDto<List<CurriculumWithLessonsDto>>>
        {
            private readonly ICurriculumService _curriculumService;
            private readonly IMapper _mapper;

            public GetAllCurriculumWithLessonsQueryHandler(ICurriculumService curriculumService, IMapper mapper)
            {
                _curriculumService = curriculumService ?? throw new ArgumentNullException(nameof(curriculumService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<List<CurriculumWithLessonsDto>>> Handle(GetAllCurriculumWithLessonsQuery request, CancellationToken cancellationToken)
            {
                var curriculumWithLessons = await _curriculumService.GetAllCurriculumWithLessonsAsync();

                if (curriculumWithLessons.Count > 0)
                {
                    var curriculumWithLessonsDtos = _mapper.Map<List<CurriculumWithLessonsDto>>(curriculumWithLessons);

                    return ResponseDto<List<CurriculumWithLessonsDto>>.Success(curriculumWithLessonsDtos, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<List<CurriculumWithLessonsDto>>.Fail("Müfredatlar bulunamadı!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
