﻿using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;

namespace Atilim.Services.Identity.Application.Features.Commands.CurriculumCommands
{
    public class CreateCurriculumCommand : IRequest<ResponseDto<int>>
    {
        public CreateCurriculumDto Curriculum { get; set; }
        public class CreateCurriculumCommandHandler : IRequestHandler<CreateCurriculumCommand, ResponseDto<int>>
        {
            private readonly ICurriculumService _curriculumService;
            private readonly IMapper _mapper;

            public CreateCurriculumCommandHandler(ICurriculumService curriculumService, IMapper mapper)
            {
                _curriculumService = curriculumService;
                _mapper = mapper;
            }

            public async Task<ResponseDto<int>> Handle(CreateCurriculumCommand request, CancellationToken cancellationToken)
            {
                var curriculum = _mapper.Map<Curriculum>(request.Curriculum);

                var curriculumId = await _curriculumService.InsertAsync(curriculum);

                if (curriculumId > 0)
                {
                    return ResponseDto<int>.Success(curriculumId, System.Net.HttpStatusCode.Created);
                }

                return ResponseDto<int>.Fail($"Müfredat oluşturma işlemi gerçekleştirilemedi!!!", System.Net.HttpStatusCode.BadRequest);

            }
        }
    }
}