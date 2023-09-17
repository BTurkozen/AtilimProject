using Atilim.Presentations.WebApplication.ViewModels.CurriculumViewModels;

namespace Atilim.Presentations.WebApplication.ViewModels.StudentViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public int StudentNo { get; set; }
        public string FullName { get; set; }
        public int CurriculumId { get; set; }

        public CurriculumWithLessonViewModel Curriculum { get; set; }

        public StudentIdentityViewModel StudentIdentity { get; set; }

        public ContactInformationViewModel ContactInformation { get; set; }
    }
}
