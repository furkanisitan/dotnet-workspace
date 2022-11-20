using DotNetWorkspace.EFCore.DataAccess.Configurations.Common;
using DotNetWorkspace.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.DataAccess.Configurations;

internal class CustomerConfiguration : EntityConfiguration<Customer, int>
{
    public override string TableName => "Customers";

    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        // Indexes
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/indexes?tabs=data-annotations
        builder.HasIndex(x => x.Username).HasDatabaseName("UX_Customers_Username").IsUnique();

        // Owned Entity
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities
        builder.OwnsOne(c => c.Person, p =>
            {
                // If nullable reference types are enabled, properties will be configured based on the C# nullability of their .NET type: string? will be configured as optional, but string will be configured as required.
                // @see https://docs.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt#required-and-optional-properties
                p.Property(x=>x.FirstName).HasColumnName(nameof(Person.FirstName)).IsRequired();
                // @see https://docs.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#maximum-length
                p.Property(x => x.LastName).HasColumnName(nameof(Person.LastName)).HasMaxLength(100);
            });

    }
}