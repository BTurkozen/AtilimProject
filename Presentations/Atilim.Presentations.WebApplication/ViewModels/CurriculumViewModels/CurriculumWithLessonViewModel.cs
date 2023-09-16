using Atilim.Presentations.WebApplication.ViewModels.LessonViewModels;

namespace Atilim.Presentations.WebApplication.ViewModels.CurriculumViewModels
{
    public class CurriculumWithLessonViewModel
    {
        public int Id { get; set; }
        public string CurriculumName { get; set; }
        public List<int> SelectedLessons { get; set; }
        public List<LessonViewModel> Lessons { get; set; }
    }
}
