using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Rockfast.ApiDatabase.Extensions
{
    public class AuditingInerceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateAuditData(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateAuditData(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateAuditData(DbContext? context)
        {
            if (context == null)
                return;

            foreach (var entity in context.ChangeTracker.Entries<IEntity>())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.DateCreated = DateTime.UtcNow;
                }

                if (entity.State == EntityState.Added || entity.State == EntityState.Modified)
                {
                    entity.Entity.DateUpdated = DateTime.UtcNow;
                }
            }
        }
    }
}
