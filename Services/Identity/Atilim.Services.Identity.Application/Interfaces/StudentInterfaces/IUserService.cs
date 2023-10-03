using Atilim.Services.Identity.Application.Dtos.StudentDtos;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(CreateStudentDto createStudentDto);
    }
}
