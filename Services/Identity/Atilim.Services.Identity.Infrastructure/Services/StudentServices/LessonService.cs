using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
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

        public async Task<List<Lesson>> GetAllLessonAsync()
        {
            return await _context.Lessons
                                 .AsNoTracking()
                                 .ToListAsync();

        }

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            var lesson = await _context.Lessons
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(l => l.Id == id) ?? null;

            return lesson;
        }

        public async Task<int> InsertAsync(Lesson lesson)
        {
            await _context.AddAsync(lesson);

            await _context.SaveChangesAsync();

            return lesson.Id;
        }

        public async Task<bool> UpdateAsync(Lesson lesson)
        {
            var hasLesson = await _context.Lessons
                                          .AnyAsync(l => l.Id == lesson.Id);

            if (hasLesson)
            {
                _context.Update(lesson);

                await _context.SaveChangesAsync();
            }

            return hasLesson;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hasLesson = await _context.Lessons.AnyAsync(l => l.Id == id);

            if (hasLesson)
            {
                var changeLesson = new Lesson()
                {
                    Id = id,
                    IsDeleted = true,
                };

                _context.Attach(changeLesson);

                _context.Entry(changeLesson)
                        .Property(l => l.IsDeleted)
                        .IsModified = true;

                await _context.SaveChangesAsync();
            }

            return hasLesson;
        }
    }
}
