namespace Atilim.Services.Identity.Domain.Entities.StudentEntities
{
    public class Curriculum : BaseEntity
    {
        public string CurriculumName { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
