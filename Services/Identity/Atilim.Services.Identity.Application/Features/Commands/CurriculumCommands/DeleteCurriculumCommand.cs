using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Commands.CurriculumCommands
{
    public class DeleteCurriculumCommand : IRequest<ResponseDto<NoContentDto>>
    {
        public int Id { get; set; }
        public class DeleteCurriculumCommandHandler : IRequestHandler<DeleteCurriculumCommand, ResponseDto<NoContentDto>>
        {
            private readonly ICurriculumService _curriculumService;
            private readonly IMapper _mapper;

            public DeleteCurriculumCommandHandler(ICurriculumService curriculumService, IMapper mapper)
            {
                _curriculumService = curriculumService;
                _mapper = mapper;
            }

            public async Task<ResponseDto<NoContentDto>> Handle(DeleteCurriculumCommand request, CancellationToken cancellationToken)
            {
                var hasDeleted = await _curriculumService.DeleteAsync(request.Id);

                if (hasDeleted)
                {
                    return ResponseDto<NoContentDto>.Success(new NoContentDto(), System.Net.HttpStatusCode.NoContent);
                }

                return ResponseDto<NoContentDto>.Fail($"{request.Id} Id'li Müfredat Silme işlemi işlemi gerçekleştirilemedi!!!", System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
