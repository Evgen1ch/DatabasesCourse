using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabasesCourse.DatabaseModel;
using DatabasesCourse.DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabasesCourse
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        //internal static void Main(string[] args)
        //{
        //    //Test product-category relations todo
        //    using (DatabaseContext db = new())
        //    {
        //        db.Database.EnsureDeleted();
        //        db.Database.EnsureCreated();
        //        var cat1 = new Category {Name = "Category1"};
        //        var cat2 = new Category {Name = "Category2"};
        //        db.Categories.AddRange(cat1, cat2);

        //        Product p1 = new() { BarCode = "1111111111111", Name = "n1", Manufacturer = "m1", Category = cat1, Price = 100, Amount = 1};
        //        Product p2 = new() { BarCode = "2222222222222", Name = "n2", Manufacturer = "m2", Category = cat2, Price = 100, Amount = 2 };
        //        Product p3 = new() { BarCode = "3333333333333", Name = "n3", Manufacturer = "m3", Category = cat2, Price = 100, Amount = 3 };
        //        Product p4 = new() { BarCode = "4444444444444", Name = "n4", Manufacturer = "m4", Category = cat1, Price = 100, Amount = 4 };
        //        Product p5 = new() { BarCode = "5555555555555", Name = "n5", Manufacturer = "m5", Category = cat2, Price = 100, Amount = 5 };
        //        Product p6 = new() { BarCode = "6666666666666", Name = "n6", Manufacturer = "m6", Category = cat1, Price = 100, Amount = 6 };
        //        db.Products.AddRange(p1, p2, p3, p4, p5, p6);
        //        db.SaveChanges();

        //        var products = db.Products.ToList();
        //        foreach (var product in products)
        //        {
        //            Debug.WriteLine($"{product.Id}\t{product.BarCode}\t{product.Name}\t{product.Category?.Name}");
        //        }
        //        Debug.WriteLine("----------------------------------------");
        //    }

        //    using (DatabaseContext db = new())
        //    {
        //        var prods = db.Products.Include(p => p.Category).OrderBy(p=>p.BarCode).ToList();
        //        foreach (var product in prods)
        //        {
        //            Debug.WriteLine($"{product.Id}\t{product.BarCode}\t{product.Name}\t{product.Category?.Name}");
        //        }
        //        Debug.WriteLine("----------------------------------------");
        //    }

        //    using (DatabaseContext db = new())
        //    {
        //        var prods = db.Products.Where(p => p.Category.Name == "Category1").Include(p => p.Category).ToList();
        //        foreach (var product in prods)
        //        {
        //            Debug.WriteLine($"{product.Id}\t{product.BarCode}\t{product.Name}\t{product.Category?.Name}");
        //        }
        //        Debug.WriteLine("----------------------------------------");
        //    }

        //    //Test User-Credentials relations todo
        //    using (DatabaseContext db = new())
        //    {
        //        User u1 = new() {FirstName = "FirstName1", LastName = "LastName1"};
        //        User u2 = new() {FirstName = "FirstName2", LastName = "LastName2"};
        //        User u3 = new() {FirstName = "FirstName3", LastName = "LastName3"};
        //        Credentials cd1 = new()
        //            {Email = "email1@gmail.com", Password = "password1", Role = Role.Employee, User = u1};
        //        Credentials cd2 = new()
        //            { Email = "email2@gmail.com", Password = "password2", Role = Role.Manager, User = u2};
        //        Credentials cd3 = new()
        //            { Email = "email3@gmail.com", Password = "password3", Role = Role.Admin, User = u3};

        //        db.Users.AddRange(u1, u2, u3);
        //        db.Credentials.AddRange(cd1, cd2, cd3);
        //        db.SaveChanges();
        //    }

        //    using (DatabaseContext db = new())
        //    {
        //        var users = db.Users.Include(u => u.Credentials).ToList();
        //        foreach (var user in users)
        //        {
        //            Debug.WriteLine($"{user.Id}\t{user.FirstName}\t{user.LastName}\t{user.Credentials?.Email}\t{user.Credentials?.Role}");
        //        }
        //        Debug.WriteLine("----------------------------------------");
        //    }

        //    using (DatabaseContext db = new())
        //    {
        //        var users = db.Users.Include(u => u.ServedOrders).ThenInclude(o=>o.Customer).ToList();
        //        foreach (var user in users)
        //        {
        //            Debug.WriteLine($"{user.Id}\t{user.FirstName}\t{user.LastName}\t{user.ServedOrders.Count}");
        //            //var lst = user.ServedOrders.FirstOrDefault().Customer;
        //        }
        //        Debug.WriteLine("----------------------------------------");
        //    }
        //}
    }
}
