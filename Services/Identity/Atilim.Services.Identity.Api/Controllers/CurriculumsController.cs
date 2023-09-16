﻿using Atilim.Services.Identity.Application.Features.Queries.CurriculumQueries;
using Atilim.Shared.CustomControllerBases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Services.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumsController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public CurriculumsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("curriculums")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAll()
        {
            return CustomActionResult(await _mediator.Send(new GetAllCurriculumQuery()));
        }

        [HttpGet("curriculum/{id}")]
        [Authorize(Roles = "admin,student")]
        public async Task<IActionResult> GetById(int id)
        {
            return CustomActionResult(await _mediator.Send(new GetCurriculumByIdQuery() { Id = id }));
        }

        [HttpGet("curriculum-with-lessons")]
        [Authorize(Roles = "admin,student")]
        public async Task<IActionResult> GetCurriculumWithLessons()
        {
            return CustomActionResult(await _mediator.Send(new GetAllCurriculumWithLessonsQuery()));
        }

        [HttpGet("curriculum-with-lessons-by-id/{id}")]
        [Authorize(Roles = "admin,student")]
        public async Task<IActionResult> GetCurriculumWithLessonsById(int id)
        {
            return CustomActionResult(await _mediator.Send(new GetCurriculumWithLessonsByIdQuery() { Id = id }));
        }
    }
}