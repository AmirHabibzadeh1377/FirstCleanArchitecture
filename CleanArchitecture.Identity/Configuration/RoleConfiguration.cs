using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Id = "047cbc16-7736-11ee-b962-0242ac120002",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
                new IdentityRole
                {
                    Id = "047cbef0-7736-11ee-b962-0242ac120002",
                    Name = "Secretary",
                    NormalizedName = "SECRETARY"
                });
        }
    }
}
