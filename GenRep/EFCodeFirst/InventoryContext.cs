using System.Data.Entity;
using EFCodeFirst.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EFCodeFirst
{
    public class InventoryContext : DbContext
    {
        public InventoryContext() : base("InventoryContext")
        {
            Database.SetInitializer<InventoryContext>(new CreateDatabaseIfNotExists<InventoryContext>());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
