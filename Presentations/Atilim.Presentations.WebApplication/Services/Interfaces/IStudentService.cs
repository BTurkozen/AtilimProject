using Atilim.Presentations.WebApplication.ViewModels.StudentViewModels;

namespace Atilim.Presentations.WebApplication.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentViewModel>> GetAllAsync();
        Task<StudentViewModel> GetByIdAsync(int id);
    }
}
