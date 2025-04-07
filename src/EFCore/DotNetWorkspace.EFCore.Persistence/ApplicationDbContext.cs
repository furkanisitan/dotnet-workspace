using System.Reflection;
using DotNetWorkspace.EFCore.Persistence.Entities;
using DotNetWorkspace.EFCore.Persistence.Entities.Joins;
using DotNetWorkspace.EFCore.Persistence.Entities.Views;
using Microsoft.EntityFrameworkCore;

namespace DotNetWorkspace.EFCore.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<ProductOrdersCount> ProductOrdersCounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // @see https://learn.microsoft.com/en-us/ef/core/modeling/#applying-all-configurations-in-an-assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}