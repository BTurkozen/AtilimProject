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

            builder.Entity<Lesson>().HasData(
               new Lesson() { Id = 1, CreatedBy = 1, LessonCode = "HUM101", LessonName = "Türk Demokrasi Tarihi", Status = true, Credit = 5 },
               new Lesson() { Id = 2, CreatedBy = 1, LessonCode = "MATH102", LessonName = "Calculus 2", Status = true, Credit = 6 },
               new Lesson() { Id = 3, CreatedBy = 1, LessonCode = "MATE103", LessonName = "Metalurjiye Giriş", Status = false, Credit = 6 },
               new Lesson() { Id = 4, CreatedBy = 1, LessonCode = "GRA105", LessonName = "Grafik Dizayn", Status = true, Credit = 5 },
               new Lesson() { Id = 5, CreatedBy = 1, LessonCode = "CMPE201", LessonName = "Bilgisayar Teknolojileri", Status = true, Credit = 4 },
               new Lesson() { Id = 6, CreatedBy = 1, LessonCode = "ENG102", LessonName = "İngilizce 2", Status = true, Credit = 4 },
               new Lesson() { Id = 7, CreatedBy = 1, LessonCode = "MATH201", LessonName = "İleri Calculus ", Status = true, Credit = 6 });

            builder.Entity<Curriculum>().HasData(
                new Curriculum() { Id = 1, CreatedBy = 1, CurriculumName = "Bilgisayar_Mühendisliği" },
                new Curriculum() { Id = 2, CreatedBy = 1, CurriculumName = "Grafik_Mühendisliği" },
                new Curriculum() { Id = 3, CreatedBy = 1, CurriculumName = "Ingiliz_Dil_Edebiyatı" });

            builder.Entity<CurriculumLesson>().HasData(
                new CurriculumLesson() { CurriculumId = 3, LessonId = 1 },
                new CurriculumLesson() { CurriculumId = 3, LessonId = 2 },
                new CurriculumLesson() { CurriculumId = 1, LessonId = 3 },
                new CurriculumLesson() { CurriculumId = 3, LessonId = 4 },
                new CurriculumLesson() { CurriculumId = 3, LessonId = 5 },
                new CurriculumLesson() { CurriculumId = 2, LessonId = 6 },
                new CurriculumLesson() { CurriculumId = 2, LessonId = 1 },
                new CurriculumLesson() { CurriculumId = 1, LessonId = 7 },
                new CurriculumLesson() { CurriculumId = 1, LessonId = 1 }
            );

            base.OnModelCreating(builder);
        }
    }
}
