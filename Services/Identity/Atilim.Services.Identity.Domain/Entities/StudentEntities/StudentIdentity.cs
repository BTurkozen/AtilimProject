namespace Atilim.Services.Identity.Domain.Entities.StudentEntities
{
    public class StudentIdentity : BaseEntity
    {
        public string TCIdentificationNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CityOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ContactInformationId { get; set; }
        public ContactInformation ContactInformation { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
