using CleanArchitecture.Identity.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Identity
{
    public class CleanArchitectureIdentityDbContext:IdentityDbContext<ApplicationUser>
    {
        #region Ctor

        public CleanArchitectureIdentityDbContext(DbContextOptions options) : base(options)
        {

        }

        #endregion
    }
}