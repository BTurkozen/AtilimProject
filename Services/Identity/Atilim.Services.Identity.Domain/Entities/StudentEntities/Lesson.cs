namespace Atilim.Services.Identity.Domain.Entities.StudentEntities
{
    public class Lesson : BaseEntity
    {
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public bool Status { get; set; }
        public int Credit { get; set; }
        public ICollection<Curriculum> Curriculums { get; set; }
    }
}
