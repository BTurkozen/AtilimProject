using Atilim.Services.Identity.Domain.Entities;
using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Atilim.Services.Identity.Infrastructure
{
    public class IdentityContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        /// <summary>
        /// Öğrenciler Tablosu
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Öğrenci Kimlik Bilgileri Tablosu
        /// </summary>
        public DbSet<StudentIdentity> StudentIdentities { get; set; }

        /// <summary>
        /// Öğrenci İletişim Bilgileri Tablosu
        /// </summary>
        public DbSet<ContactInformation> ContactInformations { get; set; }

        /// <summary>
        /// Müfredatlar Tablosu
        /// </summary>
        public DbSet<Curriculum> Curriculums { get; set; }

        /// <summary>
        /// Dersler Tablosu
        /// </summary>
        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<CurriculumLesson> CurriculumLesson { get; set; }

        /// <summary>
        /// Kullanıcı Refresh Token Tablosu
        /// </summary>
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(builder);
        }
    }
}
