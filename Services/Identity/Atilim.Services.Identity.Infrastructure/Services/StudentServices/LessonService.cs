using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Atilim.Services.Identity.Infrastructure.Services.StudentServices
{
    public class LessonService : ILessonService
    {
        private readonly IdentityContext _context;

        public LessonService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<List<LessonDto>> GetAllLessonAsync()
        {
            var lessonDtos = await _context.Lessons
                                           .AsNoTracking()
                                           .Select(l => new LessonDto
                                           {
                                               Id = l.Id,
                                               Credit = l.Credit,
                                               IsDeleted = l.IsDeleted,
                                               LessonCode = l.LessonCode,
                                               LessonName = l.LessonName,
                                               Status = l.Status,
                                           })
                                           .ToListAsync();

            return lessonDtos;
        }

        public async Task<LessonDto> GetLessonById(int id)
        {
            var lessonDto = await _context.Lessons
                                           .AsNoTracking()
                                           .Select(l => new LessonDto
                                           {
                                               Id = l.Id,
                                               Credit = l.Credit,
                                               IsDeleted = l.IsDeleted,
                                               LessonCode = l.LessonCode,
                                               LessonName = l.LessonName,
                                               Status = l.Status,
                                           })
                                           .FirstOrDefaultAsync(l => l.Id == id);

            return lessonDto;
        }
    }
}
