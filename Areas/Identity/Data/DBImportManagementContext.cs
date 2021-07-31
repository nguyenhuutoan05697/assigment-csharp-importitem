using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRNAssigment.Areas.Identity.Data;
using PRNAssigment.Models;

namespace PRNAssigment.Areas.Identity.Data
{
    public class DBImportManagementContext : IdentityDbContext<AccountManager>
    {
        public DBImportManagementContext(DbContextOptions<DBImportManagementContext> options)
            : base(options)
        {
            
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public object Supplier { get; internal set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);

            // Seed Model
            SeedSupp(builder);
            SeedProduct(builder);

        }

        private void SeedSupp(ModelBuilder builder)
        {
            builder.Entity<Supplier>().HasData(
                new Supplier() { 
                    SupplierID = 1,
                    SupplierName = "ASUS"
                },
                 new Supplier()
                 {
                     SupplierID = 2,
                     SupplierName = "MSI"
                 },
                 new Supplier()
                 {
                     SupplierID = 3,
                     SupplierName = "Acer"
                 }
            );
        }

        private void SeedProduct(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product()
                {
                    ProductID = 1,
                    ProductName = "Asus ROG STRIX SCAR",
                    Quantity = 10,
                    TotalPrice = 20000000,
                    DateIn = DateTime.Now,
                    SupplierID = 1
                },
                new Product()
                {
                    ProductID = 2,
                    ProductName = "MSI GP73 TITAN",
                    Quantity = 10,
                    TotalPrice = 48000000,
                    DateIn = DateTime.Now,
                    SupplierID = 2
                },
                new Product()
                {
                    ProductID = 3,
                    ProductName = "Acer PREDATOR",
                    Quantity = 10,
                    TotalPrice = 32000000,
                    DateIn = DateTime.Now,
                    SupplierID = 3
                }
            );
        }


        private void SeedUsers(ModelBuilder builder)
        {
            AccountManager account = new AccountManager()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",

                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",

                LockoutEnabled = false,
                PhoneNumber = "0123456789",

                SecurityStamp = Guid.NewGuid().ToString(),
            };

            PasswordHasher<AccountManager> pHash = new PasswordHasher<AccountManager>();
            account.PasswordHash = pHash.HashPassword(account, "Admin@123");
            account.EmailConfirmed = true;
           

            builder.Entity<AccountManager>().HasData(account);
          

        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() {
                    Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                    Name = "Admin",
                    //ConcurrencyStamp = "1",
                    NormalizedName = "Admin"
                },
                new IdentityRole() { 
                    Id = "c7b013f0-5201-4317-abd8-c211f91b7330", 
                    Name = "Staff", 
                    //ConcurrencyStamp = "2", 
                    NormalizedName = "Staff" 
                }
            );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {                
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    UserId = "174f7ccd-71a6-4caf-8afe-a7ed2971a88e"
                }
            );
        }
    }
}
