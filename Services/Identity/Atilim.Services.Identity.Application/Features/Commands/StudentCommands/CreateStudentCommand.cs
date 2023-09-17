using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Domain.Entities;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Atilim.Shared.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace Atilim.Services.Identity.Application.Features.Commands.StudentCommands
{
    public class CreateStudentCommand : IRequest<ResponseDto<int>>
    {
        public CreateStudentDto Student { get; set; }
        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, ResponseDto<int>>
        {
            private readonly IStudentService _studentService;
            private readonly IMapper _mapper;
            private readonly UserManager<User> _userManager;

            public CreateStudentCommandHandler(IStudentService studentService, IMapper mapper, UserManager<User> userManager)
            {
                _studentService = studentService;
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<ResponseDto<int>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {
                var user = new User()
                {
                    Email = request.Student.ContactInformation.Email,
                    Name = request.Student.StudentItentity.Name,
                    Surname = request.Student.StudentItentity.Surname,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    NormalizedEmail = request.Student.ContactInformation.Email.ToUpper(),
                    NormalizedUserName = $"{request.Student.StudentItentity.Name}.{request.Student.StudentItentity.Surname}".ToUpper(),
                    UserName = $"{request.Student.StudentItentity.Name}.{request.Student.StudentItentity.Surname}".ToLowerInvariant(),
                    PhoneNumber = request.Student.ContactInformation.MobilePhoneNumber,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                var numberByte = new byte[4];

                using var randomGen = RandomNumberGenerator.Create();

                randomGen.GetBytes(numberByte);

                var pss = Convert.ToBase64String(numberByte);

                await _userManager.CreateAsync(user, pss);

                // Mail Gönderimi eklenebilir.
                // sonuç olarak kullanıcıyı biz oluşturuyorsak kullanıcıya şifresi bir şekilde ulaştırılması gerekiyor.
                // Buranın harici Kullanıcı register işlemleri içinde bir modul yapılabilir.

                var student = new Student()
                {
                    StudentNo = request.Student.StudentNo,
                    StudentIdentity = new StudentIdentity()
                    {
                        TCIdentificationNo = request.Student.StudentItentity.TCIdentificationNo,
                        CityOfBirth = request.Student.StudentItentity.CityOfBirth,
                        DateOfBirth = request.Student.StudentItentity.DateOfBirth,
                        Name = request.Student.StudentItentity.Name,
                        Surname = request.Student.StudentItentity.Surname,
                        ContactInformation = new ContactInformation()
                        {
                            Address = request.Student.ContactInformation.Address,
                            City = request.Student.ContactInformation.City,
                            Country = request.Student.ContactInformation.Country,
                            District = request.Student.ContactInformation.District,
                            Email = request.Student.ContactInformation.Email,
                            MobilePhoneNumber = request.Student.ContactInformation.MobilePhoneNumber,
                        },
                        UserId = user.Id,
                    }
                };

                if (student is null)
                {
                    return ResponseDto<int>.Fail("Model boş!!!", System.Net.HttpStatusCode.BadRequest);
                }

                return ResponseDto<int>.Success(await _studentService.InsertAsync(student), System.Net.HttpStatusCode.Created);
            }
        }
    }
}
