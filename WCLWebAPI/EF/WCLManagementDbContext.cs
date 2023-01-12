using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WCLWebAPI.Entities;
using WCLWebAPI.Interfaces;

namespace WCLWebAPI.EF
{
    public class WCLManagementDbContext : DbContext
    {
        public WCLManagementDbContext()
        {
        }

        public WCLManagementDbContext(DbContextOptions<WCLManagementDbContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = DateTime.Now;
                    }
                    changedOrAddedItem.DateModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<TimeSheet> TimeSheets { get; set; }
    }
}
