using DotNetWorkspace.EFCore.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.Persistence.EntityConfigurations;

internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    private const string TableName = "Products";
    private const string PkColumnName = "ProductId";

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=fluent-api#table-name
        builder.ToTable(TableName);

        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=fluent-api#configuring-a-primary-key
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations#primary-key-name
        builder.HasKey(x => x.Id).HasName($"PK_{TableName}_{PkColumnName}");

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#column-names
        builder.Property(x => x.Id).HasColumnName(PkColumnName);

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#maximum-length
        builder.Property(x => x.Name).HasMaxLength(255);

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#precision-and-scale
        builder.Property(x => x.Price).HasPrecision(18, 2);
    }
}