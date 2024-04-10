using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Infraestructure.Extensions
{
    public static class EntityEntryExtension
    {
        public static IEnumerable<EntityEntry> SetDateTimeNow(this IEnumerable<EntityEntry> entityEntries, string[] propertiesNames)
        {
            EntityState[] entityStates = [EntityState.Added, EntityState.Modified];

            foreach (EntityEntry entityEntrie in entityEntries.Where(x => entityStates.Contains(x.State)))
            {
                foreach (string propertyName in propertiesNames)
                {
                    if (entityEntrie.Property(propertyName) != null)
                    {
                        entityEntrie.Property(propertyName).CurrentValue = DateTime.Now;
                    }
                }
            }

            return entityEntries;
        }

        public static IEnumerable<EntityEntry> SetDateTimeNowByEntityState(this IEnumerable<EntityEntry> entityEntries, string[] propertiesNames, EntityState entityState)
        {
            foreach (EntityEntry entityEntrie in entityEntries.Where(x => x.State.Equals(entityState)))
            {
                foreach (string propertyName in propertiesNames)
                {
                    if (entityEntrie.Property(propertyName) != null)
                    {
                        entityEntrie.Property(propertyName).CurrentValue = DateTime.Now;
                    }
                }
            }

            return entityEntries;
        }
    }
}
