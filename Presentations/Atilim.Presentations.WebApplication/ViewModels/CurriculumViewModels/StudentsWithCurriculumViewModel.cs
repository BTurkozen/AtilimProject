using Atilim.Presentations.WebApplication.ViewModels.StudentViewModels;

namespace Atilim.Presentations.WebApplication.ViewModels.CurriculumViewModels
{
    public sealed class CurriculumWithStudentsViewModel
    {
        public int Id { get; set; }
        public string CurriculumName { get; set; }

        public StudentViewModel Students { get; set; }
    }
}
