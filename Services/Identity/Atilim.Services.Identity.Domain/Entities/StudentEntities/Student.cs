
namespace Atilim.Services.Identity.Domain.Entities.StudentEntities
{
    public class Student : BaseEntity
    {
        public int StudentNo { get; set; }
        public int StudentIdentityId { get; set; }
        public StudentIdentity StudentIdentity { get; set; }
        public int? CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
    }
}
