using DotNetWorkspace.EFCore.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetWorkspace.EFCore.DataAccess.Contexts;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<City> Cities => Set<City>();
}