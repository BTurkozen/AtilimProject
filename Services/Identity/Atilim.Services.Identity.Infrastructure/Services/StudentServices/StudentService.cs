using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.EntityFrameworkCore;

namespace Atilim.Services.Identity.Infrastructure.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IdentityContext _context;

        public StudentService(IdentityContext context)
        {
            _context = context;
        }
        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var student = await _context.Students
                                        .AsNoTracking()
                                        .Include(s => s.Curriculum)
                                           .ThenInclude(c => c.CurriculumLessons)
                                               .ThenInclude(c => c.Lesson)
                                        .Include(s => s.StudentIdentity)
                                           .ThenInclude(s => s.ContactInformation)
                                        .AsSplitQuery()
                                        .FirstOrDefaultAsync(s => s.Id == studentId);

            return student;
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            var students = await _context.Students
                                         .AsNoTracking()
                                         .Include(s => s.Curriculum)
                                         .Include(s => s.StudentIdentity)
                                         .ToListAsync();

            return students;
        }

        public async Task<int> InsertAsync(Student student)
        {
            await _context.AddAsync(student);

            await _context.SaveChangesAsync();

            return student.Id;
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            var hasStudent = await _context.Students
                                           .AnyAsync(s => s.Id == student.Id);

            if (hasStudent)
            {
                _context.Update(student);

                await _context.SaveChangesAsync();
            }

            return hasStudent;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (student is not null)
            {
                var changeStutent = new Student()
                {
                    Id = id,
                    IsDeleted = true,
                };

                _context.Attach(changeStutent);

                _context.Entry(changeStutent)
                        .Property(s => s.IsDeleted)
                        .IsModified = true;

                if (student.StudentIdentity is not null)
                {
                    var changeStutentIdentity = new StudentIdentity()
                    {
                        Id = student.StudentIdentity.Id,
                        IsDeleted = true,
                    };

                    _context.Attach(changeStutentIdentity);

                    _context.Entry(changeStutentIdentity)
                            .Property(s => s.IsDeleted)
                            .IsModified = true;

                    if (student.StudentIdentity.ContactInformation is not null)
                    {
                        var changeContactInformation = new ContactInformation()
                        {
                            Id = student.StudentIdentity.ContactInformation.Id,
                            IsDeleted = true,
                        };

                        _context.Attach(changeContactInformation);

                        _context.Entry(changeContactInformation)
                                .Property(s => s.IsDeleted)
                                .IsModified = true;
                    }
                }

                await _context.SaveChangesAsync();
            }

            return student is not null;
        }
    }
}