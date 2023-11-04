using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "047cbc16-7736-11ee-b962-0242ac120002",
                UserId = "a4055170-7737-11ee-b962-0242ac120002",
            },
            new IdentityUserRole<string>
            {
                UserId = "a4055562-7737-11ee-b962-0242ac120002",
                RoleId = "047cbef0-7736-11ee-b962-0242ac120002"
            });
        }
    }
}
