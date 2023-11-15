using App.Domain.Models.Entities.Schemas.Authentication;
using App.Infraestructure.Extensions;
using App.Infraestructure.Mappings.SchemasMappings.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.DbContexts
{
    public class AuthenticationDbContext : IdentityDbContext<User, Role, string>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> dbContextOptions) : base(dbContextOptions)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        // > Entidades do contexto.
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Person> Persons { get; set; }
        // <

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("autenticacao");

            // > Mapeamento de entidades.
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new PersonMapping());
            // <

            base.OnModelCreating(modelBuilder);
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
            .SetDateTimeNow(new string[] { "CreationDate", "UpdateDate" });
    }
}
