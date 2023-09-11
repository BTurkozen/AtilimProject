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

        public async static void Seed(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var provider = scope.ServiceProvider;

            var context = provider.GetRequiredService<IdentityContext>();

            context.Database.Migrate();

            await CreateRoleSeeds(provider);

            _ = Task.Delay(200);

            await CreateUserSeeds(provider);

            _ = Task.Delay(200);

            var adminRoleInfo = await context.Roles.FirstAsync(r => r.Name == "admin");

            var adminUserInfo = await context.UserRoles.FirstOrDefaultAsync(ur => ur.RoleId == adminRoleInfo.Id);

            _userId = adminUserInfo.UserId;

            _ = Task.Delay(200);

            await CreateCurriculumSeeds(context);

            _ = Task.Delay(200);

            await CreateLessonSeeds(context);

            _ = Task.Delay(200);

            //await CreateStudentSeeds(context);

            //_ = Task.Delay(200);

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Role oluşturma işlemleri.
        /// </summary>
        /// <param name="provider"></param>
        private async static Task CreateRoleSeeds(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<UserRole>>();

            if (roleManager.Roles.Any() is false)
            {
                await roleManager.CreateAsync(new UserRole { Id = Guid.NewGuid().ToString(), Name = "admin", ConcurrencyStamp = Guid.NewGuid().ToString() });
                await roleManager.CreateAsync(new UserRole { Id = Guid.NewGuid().ToString(), Name = "student", ConcurrencyStamp = Guid.NewGuid().ToString() });
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
                var adminUser = new User()
                { Id = Guid.NewGuid().ToString(), UserName = "atilim.admin", Email = "admin@atilimProject.com" };

                await userManager.CreateAsync(adminUser, "Password_*12");

                await userManager.AddToRoleAsync(adminUser, "admin");
                #endregion

                #region Student Users

                var studentUsers = new List<User>()
                {
                    new User(){ Id = Guid.NewGuid().ToString(), UserName = "hasan.ersoy", Email = "hasan.ersoy@atilimProject.com", },
                    new User(){ Id = Guid.NewGuid().ToString(), UserName = "mehmet.yilmaz", Email = "mehmet.yilmaz@atilimProject.com" },
                    new User(){ Id = Guid.NewGuid().ToString(), UserName = "ahmet.unal", Email = "ahmet.unal@atilimProject.com" },
                    new User(){ Id = Guid.NewGuid().ToString(), UserName = "mustafa.isik", Email = "mustafa.isik@atilimProject.com" },
                    new User(){ Id = Guid.NewGuid().ToString(), UserName = "ayse.erdogan", Email = "ayse.erdogan@atilimProject.com" },
                    new User(){ Id = Guid.NewGuid().ToString(), UserName = "fatma.korkmaz", Email = "fatma.korkmaz@atilimProject.com" },
                };

                var numberByte = new byte[8];

                using var randomGen = RandomNumberGenerator.Create();

                studentUsers.ForEach(async u =>
                {
                    randomGen.GetBytes(numberByte);

                    await userManager.CreateAsync(u, Convert.ToBase64String(numberByte));
                 
                    _ = Task.Delay(200);

                    await userManager.AddToRoleAsync(u, "student");
                });

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
