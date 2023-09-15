using Atilim.Services.Identity.Application.Dtos.CurriculumDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Atilim.Services.Identity.Infrastructure.Services.StudentServices
{
    public class CurriculumService : ICurriculumService
    {
        public readonly IdentityContext _context;

        public CurriculumService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<CurriculumDto> GetCurriculumByIdAsync(int id)
        {
            var curriculum = await _context.Curriculums
                                           .AsNoTracking()
                                           .Select(c => new CurriculumDto
                                           {
                                               Id = c.Id,
                                               CurriculumName = c.CurriculumName,
                                               CreatedBy = c.CreatedBy,
                                               CreatedOn = c.CreatedOn,
                                               IsDeleted = c.IsDeleted,
                                               UpdatedBy = c.UpdatedBy,
                                               UpdatedOn = c.UpdatedOn,
                                           })
                                           .FirstOrDefaultAsync(c => c.Id == id);

            return curriculum;
        }

        public async Task<List<CurriculumDto>> GetAllCurriculumAsync()
        {
            var curriculums = await _context.Curriculums
                                           .AsNoTracking()
                                           .Select(c => new CurriculumDto
                                           {
                                               Id = c.Id,
                                               CurriculumName = c.CurriculumName,
                                               CreatedBy = c.CreatedBy,
                                               CreatedOn = c.CreatedOn,
                                               IsDeleted = c.IsDeleted,
                                               UpdatedBy = c.UpdatedBy,
                                               UpdatedOn = c.UpdatedOn,
                                           })
                                           .ToListAsync();

            return curriculums;
        }

    }
}
