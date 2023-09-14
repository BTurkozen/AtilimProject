using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface IStudentIdentityService
    {
        Task<StudentIdentityDto> GetStudentIdentityByStudentId(int studentId);
    }
}
