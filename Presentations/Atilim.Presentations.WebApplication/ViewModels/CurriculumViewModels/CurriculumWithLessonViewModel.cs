using Atilim.Presentations.WebApplication.ViewModels.LessonViewModels;

namespace Atilim.Presentations.WebApplication.ViewModels.CurriculumViewModels
{
    public class CurriculumWithLessonViewModel
    {
        public CurriculumWithLessonViewModel()
        {
            CurriculumLessons = new List<CurriculumLessonViewModel>();
        }

        public int Id { get; set; }
        public string? CurriculumName { get; set; }
        public List<int> SelectedCurriculumLessons { get; set; }
        public List<CurriculumLessonViewModel> CurriculumLessons { get; set; }
        public List<LessonViewModel> Lessons { get; set; }
        public bool HasStudent { get; set; }
    }
}
