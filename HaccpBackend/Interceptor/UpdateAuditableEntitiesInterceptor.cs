using HaccpBackend.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HaccpBackend.Interceptor
{
    public sealed class UpdateAuditableEntitiesInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var dbContext = eventData.Context;

            if(dbContext == null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<IAuditableEntity>> entries = dbContext.ChangeTracker.Entries<IAuditableEntity>();

            foreach (EntityEntry<IAuditableEntity> entityEntry in entries) { 
                if (entityEntry.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    entityEntry.Property(a => a.CreatedOnUtc).CurrentValue = DateTime.UtcNow;
                }
                if (entityEntry.State == EntityState.Modified) {

                    entityEntry.Property(a => a.ModifiedOnUtc).CurrentValue = DateTime.UtcNow;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
