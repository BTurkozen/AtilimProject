using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;

namespace Atilim.Services.Identity.Application.Dtos.StudentDtos
{
    public sealed class UpdateStudentDto
    {
        public int Id { get; set; }

        public int StudentNo { get; set; }

        public StudentIdentityDto StudentItentity { get; set; }
    }
}
