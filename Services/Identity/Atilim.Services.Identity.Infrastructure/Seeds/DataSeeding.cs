using Atilim.Services.Identity.Domain.Entities;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace Atilim.Services.Identity.Infrastructure.Seeds
{
    public static class DataSeeding
    {
        private static string _userId;
        private static string _adminRoleId;
        private static string _studentRoleId;

        public async static void Seed(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var provider = scope.ServiceProvider;

            var context = provider.GetRequiredService<IdentityContext>();

            context.Database.Migrate();

            await CreateRoleSeeds(provider);

            await CreateUserSeeds(provider);

            await CreateCurriculumSeeds(context);

            await CreateLessonSeeds(context);

            //await CreateStudentSeeds(context);

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Role oluşturma işlemleri.
        /// </summary>
        /// <param name="provider"></param>
        private async static Task CreateRoleSeeds(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<Role>>();

            if (roleManager.Roles.Any() is false)
            {
                _adminRoleId = Guid.NewGuid().ToString();

                await roleManager.CreateAsync(new Role { Id = _adminRoleId, Name = "admin", ConcurrencyStamp = Guid.NewGuid().ToString() });

                _studentRoleId = Guid.NewGuid().ToString();

                await roleManager.CreateAsync(new Role { Id = _studentRoleId, Name = "student", ConcurrencyStamp = Guid.NewGuid().ToString() });
            }
        }

        /// <summary>
        /// Kullanıcı oluşturma ve kullanıcılara role ekleme işlemleri.
        /// </summary>
        /// <param name="provider"></param>
        private async static Task CreateUserSeeds(IServiceProvider provider)
        {
            var userManager = provider.GetRequiredService<UserManager<User>>();

            if (userManager.Users.Any() is false)
            {
                #region Admin User

                _userId = Guid.NewGuid().ToString();

                var adminUser = new User()
                { UserName = "atilim.admin", Email = "admin@atilimProject.com" };

                await userManager.CreateAsync(adminUser, "Password_*12");

                var adminRole = new UserRole { RoleId = _adminRoleId, UserId = adminUser.Id };

                var context = provider.GetRequiredService<IdentityContext>();

                await context.AddAsync(adminRole);

                #endregion

                #region Student Users

                var studentUsers = new List<User>()
                {
                    new User(){ UserName = "hasan.ersoy", Email = "hasan.ersoy@atilimProject.com"},
                    new User(){ UserName = "mehmet.yilmaz", Email = "mehmet.yilmaz@atilimProject.com" },
                    new User(){ UserName = "ahmet.unal", Email = "ahmet.unal@atilimProject.com" },
                    new User(){ UserName = "mustafa.isik", Email = "mustafa.isik@atilimProject.com"},
                    new User(){ UserName = "ayse.erdogan", Email = "ayse.erdogan@atilimProject.com"},
                    new User(){ UserName = "fatma.korkmaz", Email = "fatma.korkmaz@atilimProject.com"},
                };

                var numberByte = new byte[8];

                using var randomGen = RandomNumberGenerator.Create();

                userManager = provider.GetRequiredService<UserManager<User>>();

                foreach (var u in studentUsers)
                {
                    randomGen.GetBytes(numberByte);

                    var password = Convert.ToBase64String(numberByte);

                    await userManager.CreateAsync(u, password);

                    var studentRole = new UserRole { RoleId = _studentRoleId, UserId = u.Id };

                    await context.AddAsync(studentRole);
                }

                #endregion
            }
        }

        /// <summary>
        /// Müfredat Oluşturma.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async static Task CreateCurriculumSeeds(IdentityContext context)
        {
            if (context.Curriculums.Any() is false)
            {
                var curriculums = new List<Curriculum>()
            {
                new Curriculum(){Id = Guid.NewGuid().ToString(),CreatedBy = _userId, CurriculumName = "Bilgisayar_Mühendisliği"},
                new Curriculum(){Id = Guid.NewGuid().ToString(),CreatedBy = _userId, CurriculumName = "Grafik_Mühendisliği"},
                new Curriculum(){Id = Guid.NewGuid().ToString(),CreatedBy = _userId, CurriculumName = "Ingiliz_Dil_Edebiyatı"},
            };

                await context.AddRangeAsync(curriculums);
            }

        }

        /// <summary>
        /// Ders oluşturma.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async static Task CreateLessonSeeds(IdentityContext context)
        {
            if (context.Lessons.Any() is false)
            {
                var lessons = new List<Lesson>()
            {
                new Lesson(){Id = Guid.NewGuid().ToString(), CreatedBy = _userId, LessonCode = "HUM101", LessonName = "Türk Demokrasi Tarihi", Status = true, Credit = 5},
                new Lesson(){Id = Guid.NewGuid().ToString(), CreatedBy = _userId, LessonCode = "MATH102", LessonName = "Calculus 2", Status = true, Credit =6 },
                new Lesson(){Id = Guid.NewGuid().ToString(), CreatedBy = _userId, LessonCode = "MATE103", LessonName = "Metalurjiye Giriş", Status = false, Credit = 6},
                new Lesson(){Id = Guid.NewGuid().ToString(), CreatedBy = _userId, LessonCode = "GRA105", LessonName = "Grafik Dizayn", Status = true, Credit = 5},
                new Lesson(){Id = Guid.NewGuid().ToString(), CreatedBy = _userId, LessonCode = "CMPE201", LessonName = "Bilgisayar Teknolojileri", Status = true, Credit = 4},
                new Lesson(){Id = Guid.NewGuid().ToString(), CreatedBy = _userId, LessonCode = "ENG102", LessonName = "İngilizce 2", Status = true, Credit = 4},
                new Lesson(){Id = Guid.NewGuid().ToString(), CreatedBy = _userId, LessonCode = "MATH201", LessonName = "İleri Calculus ", Status = true, Credit =6 },
            };

                await context.Curriculums.ForEachAsync(c =>
               {
                   var curriculumLessons = new List<Lesson>();

                   if (c.CurriculumName == "Bilgisayar_Mühendisliği")
                   {
                       curriculumLessons = lessons.Where(l => l.LessonCode == "MATH102" || l.LessonCode == "CMPE201" || l.LessonCode == "MATH201").ToList();
                   }
                   else if (c.CurriculumName == "Grafik_Mühendisliği")
                   {
                       curriculumLessons = lessons.Where(l => l.LessonCode == "GRA105" || l.LessonCode == "HUM101").ToList();
                   }
                   else if (c.CurriculumName == "Ingiliz_Dil_Edebiyatı")
                   {
                       curriculumLessons = lessons.Where(l => l.LessonCode == "MATH102" || l.LessonCode == "MATH201" || l.LessonCode == "ENG102").ToList();
                   }

                   c.Lessons = curriculumLessons;

                   context.UpdateRange(c.Lessons);
               });

                await context.AddRangeAsync(lessons);
            }
        }

        /// <summary>
        /// Öğrenci Ekleme işlemi.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async static Task CreateStudentSeeds(IdentityContext context)
        {
            if (context.Students.Any() is false)
            {
                var students = new List<Student>()
                {
                    new Student(){ Id = Guid.NewGuid().ToString(), CreatedBy = _userId},
                    new Student(){ Id = Guid.NewGuid().ToString(), CreatedBy = _userId},
                    new Student(){ Id = Guid.NewGuid().ToString(), CreatedBy = _userId},
                    new Student(){ Id = Guid.NewGuid().ToString(), CreatedBy = _userId},
                    new Student(){ Id = Guid.NewGuid().ToString(), CreatedBy = _userId},
                    new Student(){ Id = Guid.NewGuid().ToString(), CreatedBy = _userId},
                    new Student(){ Id = Guid.NewGuid().ToString(), CreatedBy = _userId},
                };
            }
        }
    }
}
