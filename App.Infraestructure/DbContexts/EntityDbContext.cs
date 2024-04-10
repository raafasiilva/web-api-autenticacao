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
            SetDateTimeNowInEntries();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetDateTimeNowInEntries();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetDateTimeNowInEntries() => ChangeTracker.Entries()
            .SetDateTimeNow(["CreationDate", "UpdateDate"]);
    }
}
