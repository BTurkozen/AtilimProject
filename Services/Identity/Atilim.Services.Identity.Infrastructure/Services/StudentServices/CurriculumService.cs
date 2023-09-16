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
                                           .FirstOrDefaultAsync(c => c.Id == id);

            return curriculum;
        }

        public async Task<List<Curriculum>> GetAllCurriculumAsync()
        {
            var curriculums = await _context.Curriculums
                                            .AsNoTracking()
                                            .ToListAsync();

            return curriculums;
        }

        public async Task<Curriculum> GetCurriculumWithLessonsByIdAsync(int id)
        {
            var curriculumWithLessonsDto = await _context.Curriculums
                                                         .AsNoTracking()
                                                         .Include(c => c.Lessons)
                                                         .AsSplitQuery()
                                                         .FirstOrDefaultAsync(c => c.Id == id);

            return curriculumWithLessonsDto;
        }

        public async Task<List<Curriculum>> GetAllCurriculumWithLessonsAsync()
        {
            var curriculumWithLessonsDtos = await _context.Curriculums
                                                          .AsNoTracking()
                                                          .Include(c => c.Lessons)
                                                          .AsSplitQuery()
                                                          .ToListAsync();
            return curriculumWithLessonsDtos;
        }

        public async Task<int> InsertAsync(Curriculum curriculum)
        {
            await _context.AddAsync(curriculum);

            await _context.SaveChangesAsync();

            return curriculum.Id;
        }

        public async Task<bool> UpdateAsync(Curriculum curriculum)
        {
            var hasCurriculum = await _context.Curriculums
                                              .AnyAsync(c => c.Id == curriculum.Id);

            if (hasCurriculum)
            {
                _context.Update(hasCurriculum);

                await _context.SaveChangesAsync();
            }

            return hasCurriculum;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hasCurriculum = await _context.Curriculums.AnyAsync(c => c.Id == id);

            if (hasCurriculum)
            {
                var changeCurriculum = new Lesson()
                {
                    Id = id,
                    IsDeleted = true,
                };

                _context.Attach(changeCurriculum);

                _context.Entry(changeCurriculum)
                        .Property(l => l.IsDeleted)
                        .IsModified = true;

                await _context.SaveChangesAsync();
            }

            return hasCurriculum;
        }
    }
}
