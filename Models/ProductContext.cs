using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiProducts.Models
{   
    public class ProductContext : IdentityDbContext<ApplicationUser>
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<ProductLog> ProductLog { get; set; }

        //public override int SaveChanges()
        //{
        //    var modifiedEntities = ChangeTracker.Entries()
        //        .Where(p => p.State == EntityState.Modified).ToList();
        //    var now = DateTime.UtcNow;

        //    foreach (var change in modifiedEntities)
        //    {
        //        var entityName = change.Entity.GetType().Name;
        //        var primaryKey = GetPrimaryKeyValue(change);

        //        foreach (var prop in change.OriginalValues.PropertyNames)
        //        {
        //            var originalValue = change.OriginalValues[prop].ToString();
        //            var currentValue = change.CurrentValues[prop].ToString();
        //            if (originalValue != currentValue)
        //            {
        //                ChangeLog log = new ChangeLog()
        //                {
        //                    EntityName = entityName,
        //                    PrimaryKeyValue = primaryKey.ToString(),
        //                    PropertyName = prop,
        //                    OldValue = originalValue,
        //                    NewValue = currentValue,
        //                    DateChanged = now
        //                };
        //                ChangeLogs.Add(log);
        //            }
        //        }
        //    }
        //    return base.SaveChanges();
        //}
        //object GetPrimaryKeyValue(DbEntityEntry entry)
        //{
        //    var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
        //    return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        //}
    }
}
