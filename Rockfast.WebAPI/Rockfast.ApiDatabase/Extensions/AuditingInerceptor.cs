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

        private void UpdateAuditData(DbContext? context)
        {
            if (context == null)
                return;

            foreach (var item in context.ChangeTracker.Entries<IEntity>())
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.DateCreated = DateTime.UtcNow;
                }

                if (item.State == EntityState.Added || item.State == EntityState.Modified)
                {
                    item.Entity.DateUpdated = DateTime.UtcNow;
                }
            }
        }
    }
}
