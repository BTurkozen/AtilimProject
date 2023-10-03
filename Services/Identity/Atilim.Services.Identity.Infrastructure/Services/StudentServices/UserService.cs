using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities;
using System.Security.Cryptography;

namespace Atilim.Services.Identity.Infrastructure.Services.StudentServices
{
    public class UserService : IUserService
    {
        private readonly IdentityContext _context;

        public UserService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUserAsync(CreateStudentDto createStudentDto)
        {
            var user = new User()
            {
                Email = createStudentDto.ContactInformation.Email,
                Name = createStudentDto.StudentItentity.Name,
                Surname = createStudentDto.StudentItentity.Surname,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                NormalizedEmail = createStudentDto.ContactInformation.Email.ToUpper(),
                NormalizedUserName = $"{createStudentDto.StudentItentity.Name}.{createStudentDto.StudentItentity.Surname}".ToUpper(),
                UserName = $"{createStudentDto.StudentItentity.Name}.{createStudentDto.StudentItentity.Surname}".ToLowerInvariant(),
                PhoneNumber = createStudentDto.ContactInformation.MobilePhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var numberByte = new byte[4];

            using var randomGen = RandomNumberGenerator.Create();

            randomGen.GetBytes(numberByte);

            var pss = Convert.ToBase64String(numberByte);

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user.Id;

            //await _userManager.CreateAsync(user, pss);
        }
    }
}
