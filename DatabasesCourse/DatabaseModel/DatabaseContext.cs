using System;
using System.IO;
using DatabasesCourse.DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DatabasesCourse.DatabaseModel
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DatabaseContext()
        {
            Console.WriteLine("Creating context");
            //Database.EnsureDeleted();
            Database.EnsureCreated();
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
                .Property(u=>u.FirstName).IsRequired().HasMaxLength(50);
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
                .Property(c=>c.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Credentials>()
                .Property(c => c.Password).IsRequired().HasMaxLength(50);
            builder.Entity<Credentials>()
                .Property(c => c.Role).IsRequired();

            //Customer Entity
            //todo relations
            builder.Entity<Customer>()
                .Property(c=>c.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>()
                .Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>()
                .Property(c => c.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>()
                .Property(c => c.DateTimeRegistered).IsRequired().HasMaxLength(50);
            //Customer Entity Relations

            //Category Entity
            //todo relations
            builder.Entity<Category>()
                .Property(c=>c.Name).IsRequired().HasMaxLength(100);

            //Product Entity
            //todo make double key id-barcode
            builder.Entity<Product>()
                .Property(p=>p.BarCode).IsRequired().HasMaxLength(13);
            builder.Entity<Product>()
                .Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Entity<Product>()
                .Property(p => p.Manufacturer).IsRequired().HasMaxLength(100);
            builder.Entity<Product>()
                .Property(p => p.Price).IsRequired().HasColumnType("money");
            builder.Entity<Product>()
                .Property(p => p.Amount).IsRequired().HasDefaultValue(0);
            //builder.Entity<Product>().HasKey(p => new {p.Id, p.BarCode});
            //builder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Product>().HasIndex(p => p.BarCode).IsUnique();



            //Order Entity
            //todo relations
            builder.Entity<Order>()
                .Property(o=>o.TotalCost).IsRequired().HasColumnType("money");
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
            //todo configure tables columns. day after: I dont understand what i tried to say ))
            
        }
    }
}
