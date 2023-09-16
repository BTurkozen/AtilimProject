using Atilim.Presentations.WebApplication.ViewModels.CurriculumViewModels;

namespace Atilim.Presentations.WebApplication.Services.Interfaces
{
    public interface ICurriculumService
    {
        Task<List<CurriculumViewModel>> GetAllAsync();
        Task<CurriculumViewModel> GetByIdAsync(int id);
    }
}
