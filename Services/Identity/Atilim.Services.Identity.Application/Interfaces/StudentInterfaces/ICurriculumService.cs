using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface ICurriculumService
    {
        Task<CurriculumDto> GetCurriculumByIdAsync(int id);

        Task<List<CurriculumDto>> GetAllCurriculumAsync();

        Task<CurriculumWithLessonsDto> GetCurriculumWithLessonsByIdAsync(int id);

        Task<List<CurriculumWithLessonsDto>> GetAllCurriculumWithLessonsAsync();
    }
}
