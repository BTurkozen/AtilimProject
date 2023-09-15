using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;
using System.Net;

namespace Atilim.Services.Identity.Application.Features.Queries.CurriculumQueries
{
    public class GetCurriculumByIdQuery : IRequest<ResponseDto<CurriculumDto>>
    {
        public int Id { get; set; }
        public class GetCurriculumByIdQueryHandler : IRequestHandler<GetCurriculumByIdQuery, ResponseDto<CurriculumDto>>
        {
            private readonly ICurriculumService _curriculumService;

            public GetCurriculumByIdQueryHandler(ICurriculumService curriculumService)
            {
                _curriculumService = curriculumService;
            }

            public async Task<ResponseDto<CurriculumDto>> Handle(GetCurriculumByIdQuery request, CancellationToken cancellationToken)
            {
                var curriculumDto = await _curriculumService.GetCurriculumByIdAsync(request.Id);

                if (curriculumDto is not null)
                {
                    return ResponseDto<CurriculumDto>.Success(curriculumDto, HttpStatusCode.OK);
                }

                return ResponseDto<CurriculumDto>.Fail($"{request.Id} Id'li Müfredat bulunamadı!!!", HttpStatusCode.NotFound);
            }
        }
    }
}
