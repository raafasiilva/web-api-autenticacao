using App.Infraestructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.DbContexts
{
    public abstract class EntityDbContext<TDbContext> : DbContext where TDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions<TDbContext> dbContextOptions) : base(dbContextOptions) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public override int SaveChanges()
        {
            SetNewDateTimeUtcInEntries();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetNewDateTimeUtcInEntries();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetNewDateTimeUtcInEntries() => ChangeTracker.Entries()
            .SetDateTimeByEntityState(new string[] { "CreationDate", "UpdateDate" });
    }
}
