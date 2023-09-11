namespace Atilim.Services.Identity.Domain.Entities.StudentEntities
{
    public class ContactInformation : BaseEntity
    {
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Email { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string StudentIdentityId { get; set; }
        public StudentIdentity StudentIdentity { get; set; }
    }
}
