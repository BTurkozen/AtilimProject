using Atilim.Services.Identity.Application.Dtos.LessonDtos;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface ILessonService
    {
        Task<Lesson> GetLessonByIdAsync(int id);
        Task<List<Lesson>> GetAllLessonAsync();
        Task<int> InsertAsync(Lesson lesson);
        Task UpdateAsync(Lesson lesson);
        Task DeleteAsync(Lesson lesson);
    }
}
