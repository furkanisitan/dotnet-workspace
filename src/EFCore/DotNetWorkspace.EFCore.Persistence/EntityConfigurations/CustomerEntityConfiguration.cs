using DotNetWorkspace.EFCore.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.Persistence.EntityConfigurations;

internal class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
{
    private const string TableName = "Customers";
    private const string PkColumnName = "CustomerId";

    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=fluent-api#table-name
        builder.ToTable(TableName);

        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=fluent-api#configuring-a-primary-key
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations#primary-key-name
        builder.HasKey(x => x.Id).HasName($"PK_{TableName}_{PkColumnName}");

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/indexes?tabs=fluent-api#index-uniqueness
        builder.HasIndex(x => x.PhoneNumber).HasDatabaseName("UX_Customers_PhoneNumber").IsUnique();

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#column-names
        builder.Property(x => x.Id).HasColumnName(PkColumnName);

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#maximum-length
        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);
        builder.Property(x => x.PhoneNumber).HasMaxLength(20);
    }
}