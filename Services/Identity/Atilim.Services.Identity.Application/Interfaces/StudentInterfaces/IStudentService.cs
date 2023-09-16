using Atilim.Services.Identity.Domain.Entities.StudentEntities;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsycn(int studentId);
        Task<List<Student>> GetAllStudentAsync();
    }
}
