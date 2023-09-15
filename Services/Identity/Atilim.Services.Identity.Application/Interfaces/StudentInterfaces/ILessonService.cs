using Atilim.Services.Identity.Application.Dtos.LessonDtos;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface ILessonService
    {
        Task<LessonDto> GetLessonById(int id);
        Task<List<LessonDto>> GetAllLessonAsync();
    }
}
