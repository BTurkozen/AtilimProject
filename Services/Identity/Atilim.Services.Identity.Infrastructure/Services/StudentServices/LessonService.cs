using Atilim.Services.Identity.Application.Dtos.LessonDtos;
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

        public async Task<LessonDto> GetLessonByIdAsync(int id)
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

        public async Task<int> InsertAsync(CreateLessonDto createLessonDto)
        {
            var lesson = new Lesson()
            {
                CreatedBy = createLessonDto.CreatedBy,
                Credit = createLessonDto.Credit,
                LessonCode = createLessonDto.LessonCode,
                LessonName = createLessonDto.LessonName,
                Status = createLessonDto.Status,
            };

            await _context.AddAsync(lesson);

            await _context.SaveChangesAsync();

            return lesson.Id;
        }

        public async Task UpdateAsync(UpdateLessonDto updateLessonDto)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == updateLessonDto.Id);

            if (lesson is not null)
            {
                lesson.Credit = updateLessonDto.Credit;
                lesson.LessonCode = updateLessonDto.LessonCode;
                lesson.LessonName = updateLessonDto.LessonName;
                lesson.Status = updateLessonDto.Status;
                lesson.UpdatedBy = updateLessonDto.UpdatedBy;
                lesson.UpdatedOn = DateTime.Now;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(DeleteLessonDto deleteLessonDto)
        {
            var hasLesson = await _context.Lessons.AnyAsync(l => l.Id == deleteLessonDto.Id);

            if (hasLesson)
            {
                var lesson = new Lesson()
                {
                    Id = deleteLessonDto.Id,
                    IsDeleted = true,
                };

                _context.Attach(lesson);

                _context.Entry(lesson)
                        .Property(l => l.IsDeleted)
                        .IsModified = true;

                _context.Update(deleteLessonDto);

                await _context.SaveChangesAsync();
            }
        }
    }
}
