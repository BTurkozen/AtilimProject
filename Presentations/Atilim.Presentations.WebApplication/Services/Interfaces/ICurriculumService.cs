using Atilim.Presentations.WebApplication.ViewModels.CurriculumViewModels;

namespace Atilim.Presentations.WebApplication.Services.Interfaces
{
    public interface ICurriculumService
    {
        Task<List<CurriculumViewModel>> GetAllAsync();
        Task<CurriculumViewModel> GetByIdAsync(int id);
        Task<CurriculumWithLessonViewModel> GetCurriculumWithLessonsByIdAsync(int id);
        Task<List<CurriculumWithLessonViewModel>> GetCurriculumWithLessonsAsync();
        Task<int> InsertAsync(CurriculumWithLessonViewModel curriculumViewModel);
        Task<bool> UpdateAsync(CurriculumViewModel curriculumViewModel);
        Task<bool> DeleteAsync(int id);
    }
}
