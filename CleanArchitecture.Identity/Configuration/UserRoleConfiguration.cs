using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CleanArchitecture.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(new IdentityUserRole<Guid>
            {
                RoleId = new Guid("047cbc16-7736-11ee-b962-0242ac120002"),
                UserId = new Guid("a4055170-7737-11ee-b962-0242ac120002"),
            },
            new IdentityUserRole<Guid>
            {
                UserId = new Guid("a4055562-7737-11ee-b962-0242ac120002"),
                RoleId = new Guid("047cbef0-7736-11ee-b962-0242ac120002")
            });
        }
    }
}