using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Commands.CurriculumCommands
{
    public class UpdateCurriculumCommand : IRequest<ResponseDto<NoContentDto>>
    {
        public UpdateCurriculumWithLessonsDto UpdateCurriculum { get; set; }
        public class UpdateCurriculumCommandHandler : IRequestHandler<UpdateCurriculumCommand, ResponseDto<NoContentDto>>
        {
            private readonly ICurriculumService _curriculumService;
            private readonly IMapper _mapper;

            public UpdateCurriculumCommandHandler(ICurriculumService curriculumService, IMapper mapper)
            {
                _curriculumService = curriculumService;
                _mapper = mapper;
            }

            public async Task<ResponseDto<NoContentDto>> Handle(UpdateCurriculumCommand request, CancellationToken cancellationToken)
            {
                var curriculum = new Curriculum()
                {
                    Id = request.UpdateCurriculum.Id,
                    CurriculumName = request.UpdateCurriculum.CurriculumName,
                    CurriculumLessons = request.UpdateCurriculum.CurriculumLessons.Select(cl => new CurriculumLesson
                    {
                        CurriculumId = request.UpdateCurriculum.Id,
                        LessonId = cl.LessonId,
                    }).ToList(),
                };

                var hasUpdated = await _curriculumService.UpdateAsync(curriculum);

                if (hasUpdated)
                {
                    return ResponseDto<NoContentDto>.Success(new NoContentDto(), System.Net.HttpStatusCode.NoContent);
                }

                return ResponseDto<NoContentDto>.Fail("Müfredat Güncelleme işlemi işlemi gerçekleştirilemedi!!!", System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
