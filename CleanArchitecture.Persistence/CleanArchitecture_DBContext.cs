using CleanArchitecture.Domain.Entities.Weblog;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence
{
    public class CleanArchitecture_DBContext : DbContext
    {
        public CleanArchitecture_DBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanArchitecture_DBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<WeblogCategory> WeblogCategories { get; set; }
        public DbSet<Weblog> Weblogs { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}