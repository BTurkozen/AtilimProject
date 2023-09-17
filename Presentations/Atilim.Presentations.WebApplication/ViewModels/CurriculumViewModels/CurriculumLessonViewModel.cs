using Atilim.Presentations.WebApplication.ViewModels.LessonViewModels;

namespace Atilim.Presentations.WebApplication.ViewModels.CurriculumViewModels
{
    public class CurriculumLessonViewModel
    {
        public int CurriculumId { get; set; }
        public CurriculumViewModel Curriculum { get; set; }
        public int LessonId { get; set; }
        public LessonViewModel Lesson { get; set; }
    }
}
