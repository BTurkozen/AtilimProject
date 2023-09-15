using Atilim.Services.Identity.Application.Dtos.ContactInformationDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
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

        public async Task<ContactInformationDto> GetContactInformationByStudentId(int studentIdentityId)
        {
            var contactInformation = await _context.ContactInformations
                                                   .AsNoTracking()
                                                   .FirstOrDefaultAsync(ci => ci.StudentIdentityId == studentIdentityId);

            if (contactInformation is null)
            {
                return null;
            }

            ContactInformationDto contactInformationDto = new()
            {
                Id = contactInformation.Id,
                Address = contactInformation.Address,
                City = contactInformation.City,
                Country = contactInformation.Country,
                District = contactInformation.District,
                Email = contactInformation.Email,
                IsDeleted = contactInformation.IsDeleted,
                MobilePhoneNumber = contactInformation.MobilePhoneNumber,
            };

            return contactInformationDto;
        }
    }
}
