using DatabasesCourse.DatabaseModel.Entities;
using DatabasesCourse.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace DatabasesCourse.DatabaseModel
{
    public sealed class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<LogEntry> Log { get; set; }

        private DatabaseContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public static DatabaseContext Create()
        {
            return new();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //User Entity
            builder.Entity<User>()
                .Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<User>()
                .Property(u => u.LastName).IsRequired().HasMaxLength(50);
            //User Entity Relations
            builder.Entity<User>()
                .HasOne(u => u.Credentials)
                .WithOne(c => c.User)
                .HasForeignKey<Credentials>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Credentials Entity
            builder.Entity<Credentials>()
                .Property(c => c.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Credentials>()
                .Property(c => c.Password).IsRequired().HasMaxLength(50);
            builder.Entity<Credentials>()
                .Property(c => c.Role).IsRequired();

            //Customer Entity
            builder.Entity<Customer>()
                .Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>()
                .Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>()
                .Property(c => c.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>()
                .Property(c => c.DateTimeRegistered).IsRequired().HasMaxLength(50);
            //Customer Entity Relations

            //Category Entity
            builder.Entity<Category>()
                .Property(c => c.Name).IsRequired().HasMaxLength(100);


            //Product Entity
            builder.Entity<Product>()
                .Property(p => p.BarCode).IsRequired().HasMaxLength(13);
            builder.Entity<Product>()
                .Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Entity<Product>()
                .Property(p => p.Price).IsRequired().HasColumnType("money");
            builder.Entity<Product>()
                .Property(p => p.Amount).IsRequired().HasDefaultValue(0);
            builder.Entity<Product>().HasAlternateKey(p => p.BarCode);
            builder.Entity<Product>()
                .HasOne(p => p.Manufacturer)
                .WithMany(m => m.Products)
                .HasForeignKey(p => p.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);



            //Order Entity
            builder.Entity<Order>()
                .Property(o => o.TotalCost).IsRequired().HasColumnType("money");
            builder.Entity<Order>()
                .Property(o => o.DateTime).IsRequired();
            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.ServedOrders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            //Supply entity
            builder.Entity<Supply>()
                .Property(s => s.DateTime).HasDefaultValue(DateTime.Now);

            //Order-Product relationship
            builder
                .Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders)
                .UsingEntity<OrderProduct>(
                    j => j
                        .HasOne(op => op.Product)
                        .WithMany(p => p.OrdersProducts)
                        .HasForeignKey(op => op.ProductId)
                        .OnDelete(DeleteBehavior.Restrict),
                    j => j
                        .HasOne(op => op.Order)
                        .WithMany(o => o.OrdersProducts)
                        .HasForeignKey(op => op.OrderId)
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey(op => new { op.OrderId, op.ProductId });
                        j.ToTable("OrderProduct");
                    }
                );
            builder.Entity<OrderProduct>().Property(op => op.Price).HasColumnType("money");

            //Manufacturer entity
            builder.Entity<Manufacturer>()
                .Property(m => m.Name).HasMaxLength(100).IsRequired();
            builder.Entity<Manufacturer>()
                .Property(m => m.Country).HasMaxLength(50).IsRequired();
            
            //Log entity
            builder.Entity<LogEntry>()
                .Property(l => l.Details).IsRequired().HasMaxLength(500);
            builder.Entity<LogEntry>()
                .Property(l => l.Action).IsRequired().HasMaxLength(50);


            List<Credentials> creds = new List<Credentials>
            {
                new() { Id = 1, Email = "qwerty1@gmail.com", Password = "qwerty1", Role = Role.Employee, UserId = 1},
                new() { Id = 2, Email = "qwerty2@gmail.com", Password = "qwerty2", Role = Role.Manager, UserId = 2},
                new() { Id = 3, Email = "qwerty3@gmail.com", Password = "qwerty3", Role = Role.Admin, UserId = 3 }
            };
            List<User> users = new List<User>
            {
                new() {Id = 1, FirstName = "Emp", LastName = "Employee"},
                new() {Id = 2, FirstName = "Man", LastName = "Manager"},
                new() {Id = 3, FirstName = "Adm", LastName = "Admin"},
            };
            builder.Entity<User>().HasData(users);
            builder.Entity<Credentials>().HasData(creds);
        }
    }
}
