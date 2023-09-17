namespace Atilim.Services.Identity.Application.Dtos.StudentDtos
{
    public sealed class UpdateStudentDto
    {
        public int Id { get; set; }
        public string TCIdentificationNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CityOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
