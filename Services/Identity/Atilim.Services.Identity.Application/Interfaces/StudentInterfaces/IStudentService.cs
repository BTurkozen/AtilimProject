using Atilim.Services.Identity.Application.Dtos.StudentDtos;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface IStudentService
    {
        Task<StudentDto> GetStudentByIdAsycn(int studentId);
        Task<List<StudentDto>> GetAllStudentAsync();
    }
}
