using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
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
        public async Task<StudentDto> GetStudentByIdAsycn(int studentId)
        {
            var student = await _context.Students
                                        .AsNoTracking()
                                        .Select(s => new StudentDto
                                        {
                                            Id = s.Id,
                                            FullName = $"{s.StudentIdentity.Name} {s.StudentIdentity.Surname}",
                                            IsDeleted = s.IsDeleted,
                                            StudentNo = s.StudentNo,
                                        })
                                        .FirstOrDefaultAsync(s => s.Id == studentId);

            return student;
        }

        public async Task<List<StudentDto>> GetAllStudentAsync()
        {
            var students = await _context.Students
                                         .AsNoTracking()
                                         .Select(s => new StudentDto
                                         {
                                             Id = s.Id,
                                             FullName = $"{s.StudentIdentity.Name} {s.StudentIdentity.Surname}",
                                             IsDeleted = s.IsDeleted,
                                             StudentNo = s.StudentNo,
                                         })
                                         .ToListAsync();

            return students;
        }

    }
}
