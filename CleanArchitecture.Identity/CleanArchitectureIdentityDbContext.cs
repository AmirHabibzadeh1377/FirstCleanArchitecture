using CleanArchitecture.Identity.Configuration;
using CleanArchitecture.Identity.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Identity
{
    public class CleanArchitectureIdentityDbContext:IdentityDbContext<ApplicationUser>
    {
        #region Ctor

        public CleanArchitectureIdentityDbContext(DbContextOptions<CleanArchitectureIdentityDbContext> options) : base(options)
        {
            
        }

        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }
    }
}