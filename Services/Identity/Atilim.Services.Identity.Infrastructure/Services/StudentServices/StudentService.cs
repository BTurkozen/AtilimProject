using Atilim.Services.Identity.Application.Dtos.StudentDtos;
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
        public async Task<Student> GetStudentByIdAsycn(int studentId)
        {
            var student = await _context.Students
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(s => s.Id == studentId);

            return student;
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            var students = await _context.Students
                                         .AsNoTracking()
                                         .ToListAsync();

            return students;
        }

    }
}
