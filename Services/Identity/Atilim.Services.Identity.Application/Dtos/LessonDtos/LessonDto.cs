namespace Atilim.Services.Identity.Application.Dtos.LessonDtos
{
    public sealed class LessonDto
    {
        public int Id { get; set; }
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public bool Status { get; set; }
        public int Credit { get; set; }
    }
}
