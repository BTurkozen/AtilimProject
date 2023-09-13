using Atilim.Services.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atilim.Services.Identity.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                    new User() { Id = 1, UserName = "atilim.admin", Email = "admin@atilimProject.com", Name = "atilim", Surname = "admin", SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { Id = 2, UserName = "hasan.ersoy", Email = "hasan.ersoy@atilimProject.com", Name = "hasan", Surname = "ersoy", SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { Id = 3, UserName = "mehmet.yilmaz", Email = "mehmet.yilmaz@atilimProject.com", Name = "mehmet", Surname = "yilmaz", SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { Id = 4, UserName = "ahmet.unal", Email = "ahmet.unal@atilimProject.com", Name = "ahmet", Surname = "unal", SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { Id = 5, UserName = "mustafa.isik", Email = "mustafa.isik@atilimProject.com", Name = "mustafa", Surname = "isik", SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { Id = 6, UserName = "ayse.erdogan", Email = "ayse.erdogan@atilimProject.com", Name = "ayse", Surname = "erdogan", SecurityStamp = Guid.NewGuid().ToString() },
                    new User() { Id = 7, UserName = "fatma.korkmaz", Email = "fatma.korkmaz@atilimProject.com", Name = "fatma", Surname = "korkmaz", SecurityStamp = Guid.NewGuid().ToString() }
                );
        }
    }
}
