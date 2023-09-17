using Atilim.Services.Identity.Domain.Entities.StudentEntities;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<List<Student>> GetAllStudentAsync();
        Task<int> InsertAsync(Student student);
        Task<bool> UpdateAsync(Student student);
        Task<bool> DeleteAsync(int studentId);
    }
}
