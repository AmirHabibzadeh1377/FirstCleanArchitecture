using CleanArchitecture.Identity.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CleanArchitecture.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher =new PasswordHasher <ApplicationUser>();
            builder.HasData(new ApplicationUser
            {
                Id = "a4055170-7737-11ee-b962-0242ac120002",
                FirstName = "Admin",
                LastName = "Adminian",
                Email = "Admin@LocalHost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                EmailConfirmed = true,
                UserName = "Admin@LocalHost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null,"amirh1377")
            },
            new ApplicationUser
            {
                Id = "a4055562-7737-11ee-b962-0242ac120002",
                FirstName = "System",
                LastName = "User",
                Email = "User@LocalHost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                EmailConfirmed = true,
                UserName = "User@LocalHost.com",
                NormalizedUserName = "USER@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "amirh1377")
            });
        }
    }
}
