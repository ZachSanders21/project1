using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
    public class PizzaBoxContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public PizzaBoxContext(DbContextOptions<PizzaBoxContext> options) : base(options) {}

        // protected override void OnConfiguring(DbContextOptionsBuilder builder)
        // {
        //     builder.UseSqlServer("Server=pizzaworldsanders.database.windows.net,1433;Initial Catalog=PizzaWorldDB;User ID=sqladmin;Password=Password12345;");
        // }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(s => s.EntityID);
            builder.Entity<User>().HasKey(u => u.EntityID);
            builder.Entity<APizzaModel>().HasKey(p => p.EntityID);
            builder.Entity<Order>().HasKey(o => o.EntityID);
            // builder.Entity<Order>().HasOne(o => o.Store).WithMany(s => s.Orders);
            builder.Entity<Topping>().HasKey(t => t.EntityID);
            builder.Entity<Size>().HasKey(z => z.EntityID);

            SeedData(builder);
        }
        protected void SeedData(ModelBuilder builder)
        {
            builder.Entity<Store>().HasData(new List<Store>
            {
                new Store() { EntityID = 1, Name = "one"},
                new Store() { EntityID = 2, Name = "two"}
            }
            );

        }
    }
}