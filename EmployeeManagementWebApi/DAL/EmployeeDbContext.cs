
using EmployeeManagementWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeManagementWebApi.DAL
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
                      
            modelBuilder.Entity<Products>()
            .HasMany(p => p.Orders)
            .WithOne(o => o.Product)
            .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "John Doe", Email = "john.doe@example.com", JobTitle = "Software Developer" },
                new Employee { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", JobTitle = "Project Manager" }
            );
            modelBuilder.Entity<Products>().HasData(
              new Products { Id = 1, Name = "Product A", Price = 50 },
              new Products { Id = 2, Name = "Product B", Price = 100 }
            );
            modelBuilder.Entity<Orders>().HasData(
               new Orders { Id = 1, ProductId = 1, OrderDate = DateTime.Now, Quantity = 2 },
               new Orders { Id = 2, ProductId = 2, OrderDate = DateTime.Now.AddDays(-10), Quantity = 1 }

          );

        }
    }
}
