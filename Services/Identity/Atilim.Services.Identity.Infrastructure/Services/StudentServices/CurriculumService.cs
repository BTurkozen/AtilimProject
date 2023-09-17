using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
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

        public async Task<Curriculum> GetCurriculumByIdAsync(int id)
        {
            var curriculum = await _context.Curriculums
                                           .AsNoTracking()
                                           .Include(c => c.CurriculumLessons)
                                             .ThenInclude(cl => cl.Lesson)
                                           .FirstOrDefaultAsync(c => c.Id == id);

            return curriculum;
        }

        public async Task<List<Curriculum>> GetAllCurriculumAsync()
        {
            var curriculums = await _context.Curriculums
                                            .AsNoTracking()
                                            .Include(c => c.CurriculumLessons)
                                               .ThenInclude(cl => cl.Lesson)
                                            .ToListAsync();

            return curriculums;
        }

        public async Task<Curriculum> GetCurriculumWithLessonsByIdAsync(int id)
        {
            var curriculumWithLessonsDto = await _context.Curriculums
                                                         .AsNoTracking()
                                                         .Include(c => c.CurriculumLessons)
                                                            .ThenInclude(cl => cl.Lesson)
                                                         .AsSplitQuery()
                                                         .FirstOrDefaultAsync(c => c.Id == id);

            return curriculumWithLessonsDto;
        }

        public async Task<List<Curriculum>> GetAllCurriculumWithLessonsAsync()
        {
            var curriculumWithLessonsDtos = await _context.Curriculums
                                                          .AsNoTracking()
                                                          .Include(c => c.CurriculumLessons)
                                                            .ThenInclude(cl => cl.Lesson)
                                                          .AsSplitQuery()
                                                          .ToListAsync();
            return curriculumWithLessonsDtos;
        }

        public async Task<int> InsertAsync(Curriculum curriculum)
        {
            await _context.Curriculums.AddAsync(curriculum);

            await _context.SaveChangesAsync();

            return curriculum.Id;
        }

        public async Task<bool> UpdateAsync(Curriculum curriculum)
        {
            var hasCurriculum = await _context.Curriculums
                                              .AnyAsync(c => c.Id == curriculum.Id);

            if (hasCurriculum)
            {
                var removeCurriculumLessons = await _context.CurriculumLesson.Where(cl => cl.CurriculumId == curriculum.Id).ToArrayAsync();

                _context.RemoveRange(removeCurriculumLessons);

                await _context.SaveChangesAsync();

                _context.Curriculums.Update(curriculum);

                await _context.CurriculumLesson.AddRangeAsync(curriculum.CurriculumLessons);

                await _context.SaveChangesAsync();
            }

            return hasCurriculum;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var curriculum = await _context.Curriculums
                                           .Include(c => c.CurriculumLessons)
                                           .FirstOrDefaultAsync(c => c.Id == id);

            if (curriculum is not null)
            {
                //var changeCurriculum = new Lesson()
                //{
                //    Id = id,
                //    IsDeleted = true,
                //};

                //_context.Attach(changeCurriculum);

                //_context.Entry(changeCurriculum)
                //        .Property(l => l.IsDeleted)
                //        .IsModified = true;

                curriculum.IsDeleted = true;

                curriculum.CurriculumLessons.Clear();

                await _context.SaveChangesAsync();
            }

            return curriculum is not null;
        }
    }
}
