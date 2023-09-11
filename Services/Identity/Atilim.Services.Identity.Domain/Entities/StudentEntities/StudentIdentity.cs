namespace Atilim.Services.Identity.Domain.Entities.StudentEntities
{
    public class StudentIdentity : BaseEntity
    {
        public int TCIdentificationNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CityOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactInformationId { get; set; }
        public ContactInformation ContactInformation { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
