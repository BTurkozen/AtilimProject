
using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Queries.CurriculumQueries
{
    public class GetAllCurriculumQuery : IRequest<ResponseDto<List<CurriculumDto>>>
    {
        public class GetAllCurriculumQueryHandler : IRequestHandler<GetAllCurriculumQuery, ResponseDto<List<CurriculumDto>>>
        {
            private readonly ICurriculumService _curriculumService;
            private readonly IMapper _mapper;

            public GetAllCurriculumQueryHandler(ICurriculumService curriculumService, IMapper mapper)
            {
                _curriculumService = curriculumService ?? throw new ArgumentNullException(nameof(curriculumService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<List<CurriculumDto>>> Handle(GetAllCurriculumQuery request, CancellationToken cancellationToken)
            {
                var curriculums = await _curriculumService.GetAllCurriculumAsync();

                if (curriculums.Count > 0)
                {
                    var curriculumDtos = _mapper.Map<List<CurriculumDto>>(curriculums);

                    return ResponseDto<List<CurriculumDto>>.Success(curriculumDtos, System.Net.HttpStatusCode.OK);
                }

                return ResponseDto<List<CurriculumDto>>.Fail("Listelenecek Müfredatlar bulunamadı.", System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}
