namespace Atilim.Services.Identity.Application.Dtos.ContactInformationDtos
{
    public sealed class UpdateContactInformationDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Email { get; set; }
        public string MobilePhoneNumber { get; set; }
        public int StudentIdentityId { get; set; }
    }
}
