namespace Atilim.Services.Identity.Domain.Entities.StudentEntities
{
    public class CurriculumLesson
    {
        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
