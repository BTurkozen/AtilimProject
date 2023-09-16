using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.EntityFrameworkCore;

namespace Atilim.Services.Identity.Infrastructure.Services.StudentServices
{
    public class StudentIdentityService : IStudentIdentityService
    {
        private readonly IdentityContext _context;

        public StudentIdentityService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<StudentIdentity> GetStudentIdentityById(int id)
        {
            var studentIndetity = await _context.StudentIdentities
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(si => si.Id == id);

            if (studentIndetity is null)
            {
                return null;
            }

            return studentIndetity;
        }

        public async Task<StudentIdentity> GetStudentIdentityByStudentId(int studentId)
        {
            var studentIndetity = await _context.StudentIdentities.AsNoTracking().FirstOrDefaultAsync(si => si.StudentId == studentId);

            if (studentIndetity is null)
            {
                return null;
            }

            return studentIndetity;
        }
    }
}
