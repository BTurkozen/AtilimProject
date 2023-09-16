using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Shared.Dtos;
using AutoMapper;
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
            private readonly IMapper _mapper;

            public GetCurriculumByIdQueryHandler(ICurriculumService curriculumService, IMapper mapper)
            {
                _curriculumService = curriculumService ?? throw new ArgumentNullException(nameof(curriculumService));
                _mapper = mapper;
            }

            public async Task<ResponseDto<CurriculumDto>> Handle(GetCurriculumByIdQuery request, CancellationToken cancellationToken)
            {
                var curriculum = await _curriculumService.GetCurriculumByIdAsync(request.Id);

                if (curriculum is not null)
                {
                    var curriculumDto = _mapper.Map<CurriculumDto>(curriculum);

                    return ResponseDto<CurriculumDto>.Success(curriculumDto, HttpStatusCode.OK);
                }

                return ResponseDto<CurriculumDto>.Fail($"{request.Id} Id'li Müfredat bulunamadı!!!", HttpStatusCode.NotFound);
            }
        }
    }
}
