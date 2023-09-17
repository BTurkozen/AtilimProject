using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Dtos.LessonDtos;
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
                    var curriculumWithLessonsDtos = curriculumWithLessons.Select(c => new CurriculumWithLessonsDto
                    {
                        Id = c.Id,
                        CurriculumName = c.CurriculumName,
                        IsDeleted = c.IsDeleted,
                        CurriculumLessons = c.CurriculumLessons.Select(cl => new CurriculumLessonDto
                        {
                            CurriculumId = cl.CurriculumId,
                            Curriculum = new CurriculumDto
                            {
                                CurriculumName = cl.Curriculum.CurriculumName,
                                Id = cl.Curriculum.Id,
                            },
                            LessonId = cl.LessonId,
                            Lesson = new LessonDto
                            {
                                Id = cl.LessonId,
                                Credit = cl.Lesson.Credit,
                                LessonCode = cl.Lesson.LessonCode,
                                LessonName = cl.Lesson.LessonName,
                                Status = cl.Lesson.Status
                            }
                        }).ToList()
                    }).ToList();

                    return ResponseDto<List<CurriculumWithLessonsDto>>.Success(curriculumWithLessonsDtos, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<List<CurriculumWithLessonsDto>>.Fail("Müfredatlar bulunamadı!!!", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
