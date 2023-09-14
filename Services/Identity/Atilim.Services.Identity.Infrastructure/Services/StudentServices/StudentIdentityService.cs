using Atilim.Services.Identity.Application.Dtos.StudentIdentityDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.EntityFrameworkCore;

namespace Atilim.Services.Identity.Infrastructure.Services.StudentServices
{
    public class StudentIdentityService : IStudentIdentityService
    {
        private readonly IdentityContext _context;

        public StudentIdentityService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<StudentIdentityDto> GetStudentIdentityById(int id)
        {
            var studentIndetity = await _context.StudentIdentities
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(si => si.Id == id);

            if (studentIndetity is not null)
            {
                // TODO: BURAK Log ekle

                return null;
            }

            var studentIndetityDto = new StudentIdentityDto
            {
                Id = studentIndetity.Id,
                TCIdentificationNo = studentIndetity.TCIdentificationNo,
                Name = studentIndetity.Name,
                Surname = studentIndetity.Surname,
                CityOfBirth = studentIndetity.CityOfBirth,
                DateOfBirth = studentIndetity.DateOfBirth,
            };

            return studentIndetityDto;
        }

        public async Task<StudentIdentityDto> GetStudentIdentityByStudentId(int studentId)
        {
            var studentIndetity = await _context.StudentIdentities.AsNoTracking().FirstOrDefaultAsync(si => si.StudentId == studentId);

            if (studentIndetity is not null)
            {
                // TODO: BURAK Log ekle

                return null;
            }

            var studentIndetityDto = new StudentIdentityDto
            {
                Id = studentIndetity.Id,
                TCIdentificationNo = studentIndetity.TCIdentificationNo,
                Name = studentIndetity.Name,
                Surname = studentIndetity.Surname,
                CityOfBirth = studentIndetity.CityOfBirth,
                CreatedBy = studentIndetity.CreatedBy,
                CreatedOn = studentIndetity.CreatedOn,
                DateOfBirth = studentIndetity.DateOfBirth,
                IsDeleted = studentIndetity.IsDeleted,
                UpdatedBy = studentIndetity.UpdatedBy,
                UpdatedOn = studentIndetity.UpdatedOn,
            };

            return studentIndetityDto;
        }
    }
}
