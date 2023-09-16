using Atilim.Services.Identity.Domain.Entities.StudentEntities;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface ICurriculumService
    {
        Task<Curriculum> GetCurriculumByIdAsync(int id);

        Task<List<Curriculum>> GetAllCurriculumAsync();

        Task<Curriculum> GetCurriculumWithLessonsByIdAsync(int id);

        Task<List<Curriculum>> GetAllCurriculumWithLessonsAsync();

        Task<int> InsertAsync(Curriculum curriculum);
        Task<bool> UpdateAsync(Curriculum curriculum);
        Task<bool> DeleteAsync(int id);
    }
}
