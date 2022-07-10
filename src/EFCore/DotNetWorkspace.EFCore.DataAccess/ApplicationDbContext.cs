using DotNetWorkspace.EFCore.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetWorkspace.EFCore.DataAccess;

public class ApplicationDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Product> Products => Set<Product>();

}