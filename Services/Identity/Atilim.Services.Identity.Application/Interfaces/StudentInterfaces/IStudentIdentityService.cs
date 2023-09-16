using Atilim.Services.Identity.Domain.Entities.StudentEntities;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface IStudentIdentityService
    {
        Task<StudentIdentity> GetStudentIdentityById(int id);
        Task<StudentIdentity> GetStudentIdentityByStudentId(int studentId);
    }
}
