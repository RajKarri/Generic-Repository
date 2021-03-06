﻿using Models;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst
{
    public class InventoryContext : DbContext
    {
        public string connection { get; set; }

        public InventoryContext(string connection) : base()
        {
            this.connection = connection;
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection);            
        }
    }
}
