namespace Atilim.Services.Identity.Domain.Entities.StudentEntities
{
    public class Curriculum : BaseEntity
    {
        public string CurriculumName { get; set; }

        public ICollection<CurriculumLesson> CurriculumLessons { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
