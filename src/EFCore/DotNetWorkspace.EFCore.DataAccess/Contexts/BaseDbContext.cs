using DotNetWorkspace.EFCore.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace DotNetWorkspace.EFCore.DataAccess.Contexts
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext()
        {
        }

        protected BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.Entity is IEntityDate entityDate)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entityDate.UpdatedDate = utcNow;
                            entry.Property(nameof(IEntityDate.UpdatedDate)).IsModified = false;
                            break;

                        case EntityState.Added:
                            entityDate.CreatedDate = utcNow;
                            break;
                    }
                }
            }
        }
    }
}
