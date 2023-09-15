using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.CurriculumQueries
{
    public class GetAllCurriculumQuery : IRequest<ResponseDto<List<CurriculumDto>>>
    {
        public class GetAllCurriculumQueryHandler : IRequestHandler<GetAllCurriculumQuery, ResponseDto<List<CurriculumDto>>>
        {
            private readonly ICurriculumService _curriculumService;

            public GetAllCurriculumQueryHandler(ICurriculumService curriculumService)
            {
                _curriculumService = curriculumService;
            }

            public async Task<ResponseDto<List<CurriculumDto>>> Handle(GetAllCurriculumQuery request, CancellationToken cancellationToken)
            {
                var curriculumDtos = await _curriculumService.GetAllCurriculumAsync();

                if (curriculumDtos.Count > 0)
                {
                    return ResponseDto<List<CurriculumDto>>.Success(curriculumDtos, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<List<CurriculumDto>>.Fail("Listelenecek Müfredatlar bulunamadı.", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
