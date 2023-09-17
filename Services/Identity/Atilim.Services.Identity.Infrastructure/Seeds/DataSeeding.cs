using Atilim.Services.Identity.Domain.Entities;
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

        }

        /// <summary>
        /// Kullanıcı oluşturma ve kullanıcılara role ekleme işlemleri.
        /// </summary>
        /// <param name="provider"></param>
        private static void CreateUserSeeds(IServiceProvider provider)
        {
            var userManager = provider.GetRequiredService<UserManager<User>>();

            if (userManager.Users.Any() && userManager.Users.Any(u => u.PasswordHash == null))
            {
                var users = userManager.Users.ToList();

                #region Admin User

                var adminUser = users.FirstOrDefault(u => u.Id == 1);

                userManager.AddPasswordAsync(adminUser, "Password_*12").Wait();

                userManager.AddToRoleAsync(adminUser, "admin").Wait();

                #endregion

                #region Student Users

                var studentUsers = users.Where(u => u.Id != 1).ToList();

                var numberByte = new byte[8];

                using var randomGen = RandomNumberGenerator.Create();

                for (int i = 0; i < studentUsers.Count; i++)
                {
                    randomGen.GetBytes(numberByte);

                    var password = Convert.ToBase64String(numberByte);

                    userManager.AddPasswordAsync(studentUsers[i], password).Wait();

                    if (string.IsNullOrEmpty(studentUsers[i].ConcurrencyStamp))
                    {
                        userManager.GenerateConcurrencyStampAsync(studentUsers[i]).Wait();
                    }

                    if (string.IsNullOrEmpty(studentUsers[i].SecurityStamp))
                    {
                        userManager.GetSecurityStampAsync(studentUsers[i]).Wait();
                    }

                    userManager.AddToRoleAsync(studentUsers[i], "student").Wait();
                }

                #endregion
            }
        }
    }
}
