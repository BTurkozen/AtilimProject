﻿using Atilim.Services.Identity.Domain.Entities;
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

            CreateUserSeeds(provider);

            CreateLessonSeeds(context);
        }

        /// <summary>
        /// Kullanıcı oluşturma ve kullanıcılara role ekleme işlemleri.
        /// </summary>
        /// <param name="provider"></param>
        private static void CreateUserSeeds(IServiceProvider provider)
        {
            var userManager = provider.GetRequiredService<UserManager<User>>();

            if (userManager.Users.Any() is false)
            {
                #region Admin User

                var adminUser = new User()
                { UserName = "atilim.admin", Email = "admin@atilimProject.com", Name = "atilim", Surname = "admin" };

                userManager.CreateAsync(adminUser, "Password_*12").Wait();

                userManager.AddToRoleAsync(adminUser, "admin").Wait();

                #endregion

                #region Student Users

                var studentUsers = new List<User>()
                {
                    new User(){ UserName = "hasan.ersoy", Email = "hasan.ersoy@atilimProject.com",Name ="hasan", Surname="ersoy"},
                    new User(){ UserName = "mehmet.yilmaz", Email = "mehmet.yilmaz@atilimProject.com",Name ="mehmet", Surname="yilmaz"},
                    new User(){ UserName = "ahmet.unal", Email = "ahmet.unal@atilimProject.com",Name ="ahmet", Surname="unal"},
                    new User(){ UserName = "mustafa.isik", Email = "mustafa.isik@atilimProject.com",Name ="mustafa", Surname="isik"},
                    new User(){ UserName = "ayse.erdogan", Email = "ayse.erdogan@atilimProject.com",Name ="ayse", Surname="erdogan"},
                    new User(){ UserName = "fatma.korkmaz", Email = "fatma.korkmaz@atilimProject.com",Name ="fatma", Surname="korkmaz"},
                };

                var numberByte = new byte[8];

                using var randomGen = RandomNumberGenerator.Create();

                //userManager = provider.GetRequiredService<UserManager<User>>();

                for (int i = 0; i < studentUsers.Count; i++)
                {
                    randomGen.GetBytes(numberByte);

                    var password = Convert.ToBase64String(numberByte);

                    userManager.CreateAsync(studentUsers[i], password).Wait();

                    userManager.GenerateConcurrencyStampAsync(studentUsers[i]).Wait();

                    userManager.GetSecurityStampAsync(studentUsers[i]).Wait();

                    userManager.AddToRoleAsync(studentUsers[i], "student").Wait();
                }

                #endregion
            }
        }

        /// <summary>
        /// Ders oluşturma.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static void CreateLessonSeeds(IdentityContext context)
        {
            if (context.Lessons.Any() && context.Curriculums.Select(c => c.Lessons).Any() is false)
            {
                var curriculums = context.Curriculums.ToList();

                var lessons = context.Lessons.ToList();

                for (int i = 0; i < curriculums.Count; i++)
                {
                    var curriculumLessons = new List<Lesson>();

                    if (curriculums[i].CurriculumName == "Bilgisayar_Mühendisliği")
                    {
                        curriculumLessons = lessons.Where(l => l.LessonCode == "MATH102" || l.LessonCode == "CMPE201" || l.LessonCode == "MATH201").ToList();
                    }
                    else if (curriculums[i].CurriculumName == "Grafik_Mühendisliği")
                    {
                        curriculumLessons = lessons.Where(l => l.LessonCode == "GRA105" || l.LessonCode == "HUM101").ToList();
                    }
                    else if (curriculums[i].CurriculumName == "Ingiliz_Dil_Edebiyatı")
                    {
                        curriculumLessons = lessons.Where(l => l.LessonCode == "MATH102" || l.LessonCode == "MATH201" || l.LessonCode == "ENG102").ToList();
                    }

                    curriculums[i].Lessons = curriculumLessons;

                    context.UpdateRange(curriculums[i].Lessons);
                }

                context.SaveChanges();
            }
        }
    }
}
