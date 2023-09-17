using Atilim.Presentations.WebApplication.ViewModels.StudentViewModels;

namespace Atilim.Presentations.WebApplication.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentViewModel>> GetAllAsync();
        Task<StudentViewModel> GetByIdAsync(int id);

        Task<StudentIdentityViewModel> GetStudentIdentityByIdAsync(int id);
        Task<StudentIdentityViewModel> GetContactInformationByIdAsync(int id);

        Task<int> InsertAsync(CreateStudentViewModel createStudentViewModel);
        Task<bool> UpdateStudentIdentityAsync(StudentIdentityViewModel studentIdentityViewModel);

        Task<bool> UpdateContactInformationAsync(ContactInformationViewModel contactInformationViewModel);
    }
}
