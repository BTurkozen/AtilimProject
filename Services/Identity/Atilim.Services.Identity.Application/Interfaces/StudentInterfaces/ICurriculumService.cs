using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;

namespace Atilim.Services.Identity.Application.Interfaces.StudentInterfaces
{
    public interface ICurriculumService
    {
        Task<CurriculumDto> GetCurriculumByIdAsync(int id);
        Task<List<CurriculumDto>> GetAllCurriculumAsync();
    }
}
