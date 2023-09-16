using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;

namespace Atilim.Services.Identity.Application.Dtos.StudentDtos
{
    public sealed class CreateStudentDto
    {
        public int StudentNo { get; set; }

        public StudentIdentityDto StudentItentity { get; set; }
    }
}
