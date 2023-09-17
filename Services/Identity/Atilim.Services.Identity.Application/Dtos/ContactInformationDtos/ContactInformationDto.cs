using Atilim.Services.Identity.Application.Wrappers;

namespace Atilim.Services.Identity.Application.Dtos.ContactInformationDtos
{
    public sealed class ContactInformationDto : BaseEntityDto
    {
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Email { get; set; }
        public string MobilePhoneNumber { get; set; }
        public int StudentIdentityId { get; set; }
    }
}
