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

        public async Task<ContactInformation> GetContactInformationById(int id)
        {
            var contactInformation = await _context.ContactInformations
                                                   .AsNoTracking()
                                                   .FirstOrDefaultAsync(ci => ci.Id == id);

            if (contactInformation is null)
            {
                return null;
            }

            return contactInformation;
        }

        public async Task<bool> UpdateAsync(ContactInformation contactInformation)
        {
            var hasContactInformation = await _context.ContactInformations
                                                   .AnyAsync(l => l.Id == contactInformation.Id);

            if (hasContactInformation)
            {
                _context.Update(contactInformation);

                await _context.SaveChangesAsync();
            }

            return hasContactInformation;
        }
    }
}
