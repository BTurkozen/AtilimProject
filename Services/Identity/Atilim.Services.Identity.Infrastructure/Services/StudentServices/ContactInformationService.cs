using Atilim.Services.Identity.Application.Dtos.ContactInformationDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.EntityFrameworkCore;

namespace Atilim.Services.Identity.Infrastructure.Services.StudentServices
{
    public class ContactInformationService : IContactInformationService
    {
        private readonly IdentityContext _context;

        public ContactInformationService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<ContactInformation> GetContactInformationByStudentId(int studentIdentityId)
        {
            var contactInformation = await _context.ContactInformations
                                                   .AsNoTracking()
                                                   .FirstOrDefaultAsync(ci => ci.StudentIdentityId == studentIdentityId);

            if (contactInformation is null)
            {
                return null;
            }

            return contactInformation;
        }
    }
}
