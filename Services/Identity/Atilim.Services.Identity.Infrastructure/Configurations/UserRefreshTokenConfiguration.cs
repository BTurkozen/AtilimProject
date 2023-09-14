using Atilim.Services.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atilim.Services.Identity.Infrastructure.Configurations
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            //builder.HasKey(b => b.UserId);

            builder.HasKey(ent => ent.UserId);
            builder.Property(ent => ent.UserId).ValueGeneratedNever();

            builder.Property(b => b.Code).IsRequired().HasMaxLength(200);
        }
    }
}
