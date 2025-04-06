using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DotNetWorkspace.EFCore.Persistence;

internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DotNetWorkspace;Integrated Security=true");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}