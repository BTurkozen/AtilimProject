﻿using Atilim.Services.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atilim.Services.Identity.Infrastructure.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.Property(b => b.UserId).ValueGeneratedOnAdd();

            builder.HasKey(b => b.UserId);

            builder.HasOne(b => b.User)
                   .WithMany(b => b.UserRoles)
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Role)
                   .WithMany(b => b.UserRoles)
                   .HasForeignKey(b => b.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
