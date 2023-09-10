
namespace Atilim.Services.Identity.Domain.Entities.StudentEntities
{
    public class Student : BaseEntity
    {
        public int StudentNo { get; set; }
        public string StudentIdentityId { get; set; }
        public StudentIdentity StudentIdentity { get; set; }
        public string CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
    }
}
