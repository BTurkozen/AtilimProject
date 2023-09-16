using Atilim.Presentations.WebApplication.ViewModels.LessonViewModels;

namespace Atilim.Presentations.WebApplication.Services.Interfaces
{
    public interface ILessonService
    {
        Task<List<LessonViewModel>> GetAll();
        Task<LessonViewModel> GetById(int id);
    }
}
