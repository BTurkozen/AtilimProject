using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Shared.Dtos;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface ILessonService
    {
        Task<LessonDto> GetLessonByIdAsync(int id);
        Task<List<LessonDto>> GetAllLessonAsync();
        Task<int> InsertAsync(CreateLessonDto createLessonDto);
        Task UpdateAsync(UpdateLessonDto updateLessonDto);
        Task DeleteAsync(DeleteLessonDto deleteLessonDto);
    }
}
