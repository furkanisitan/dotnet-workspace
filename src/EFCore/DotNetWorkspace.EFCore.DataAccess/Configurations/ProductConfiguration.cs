using DotNetWorkspace.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.DataAccess.Configurations;

internal class ProductConfiguration : EntityConfiguration<Product, int>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);

        // Indexes
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/indexes?tabs=data-annotations
        builder.HasIndex(x => x.Name).HasDatabaseName("IX_Products_Name");
    }
}