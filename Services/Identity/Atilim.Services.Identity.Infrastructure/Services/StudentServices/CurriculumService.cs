using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Atilim.Services.Identity.Infrastructure.Services.StudentServices
{
    public class CurriculumService : ICurriculumService
    {
        public readonly IdentityContext _context;

        public CurriculumService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<CurriculumDto> GetCurriculumByIdAsync(int id)
        {
            var curriculum = await _context.Curriculums
                                           .AsNoTracking()
                                           .Select(c => new CurriculumDto
                                           {
                                               Id = c.Id,
                                               CurriculumName = c.CurriculumName,
                                               IsDeleted = c.IsDeleted,
                                           })
                                           .FirstOrDefaultAsync(c => c.Id == id);

            return curriculum;
        }

        public async Task<List<CurriculumDto>> GetAllCurriculumAsync()
        {
            var curriculums = await _context.Curriculums
                                           .AsNoTracking()
                                           .Select(c => new CurriculumDto
                                           {
                                               Id = c.Id,
                                               CurriculumName = c.CurriculumName,
                                               IsDeleted = c.IsDeleted,
                                           })
                                           .ToListAsync();

            return curriculums;
        }

        public async Task<CurriculumWithLessonsDto> GetCurriculumWithLessonsByIdAsync(int id)
        {
            var curriculumWithLessonsDto = await _context.Curriculums
                                                         .AsNoTracking()
                                                         .Include(c => c.Lessons)
                                                         .AsSplitQuery()
                                                         .Select(c => new CurriculumWithLessonsDto
                                                         {
                                                             Id = c.Id,
                                                             CurriculumName = c.CurriculumName,
                                                             IsDeleted = c.IsDeleted,
                                                             Lessons = c.Lessons
                                                                        .Select(l => new LessonDto
                                                                        {
                                                                            Id = l.Id,
                                                                            IsDeleted = l.IsDeleted,
                                                                            Credit = l.Credit,
                                                                            LessonCode = l.LessonCode,
                                                                            LessonName = l.LessonName,
                                                                            Status = l.Status,
                                                                        })
                                                                        .ToList()
                                                         })
                                                         .FirstOrDefaultAsync(c => c.Id == id);

            return curriculumWithLessonsDto;
        }

        public async Task<List<CurriculumWithLessonsDto>> GetAllCurriculumWithLessonsAsync()
        {
            var curriculumWithLessonsDtos = await _context.Curriculums
                                                          .AsNoTracking()
                                                          .Include(c => c.Lessons)
                                                          .AsSplitQuery()
                                                          .Select(c => new CurriculumWithLessonsDto
                                                          {
                                                              Id = c.Id,
                                                              CurriculumName = c.CurriculumName,
                                                              IsDeleted = c.IsDeleted,
                                                              Lessons = c.Lessons
                                                                         .Select(l => new LessonDto
                                                                         {
                                                                             Id = l.Id,
                                                                             IsDeleted = l.IsDeleted,
                                                                             Credit = l.Credit,
                                                                             LessonCode = l.LessonCode,
                                                                             LessonName = l.LessonName,
                                                                             Status = l.Status,
                                                                         })
                                                                         .ToList()
                                                          })
                                                          .ToListAsync();
            return curriculumWithLessonsDtos;
        }
    }
}
