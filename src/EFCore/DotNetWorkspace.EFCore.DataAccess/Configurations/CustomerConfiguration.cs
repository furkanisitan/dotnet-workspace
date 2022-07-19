using DotNetWorkspace.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.DataAccess.Configurations;

internal class CustomerConfiguration : EntityConfiguration<Customer, int>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        // By convention, each entity type will be set up to map to a database table with the same name as the DbSet property that exposes the entity.
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=data-annotations#table-name
        //builder.ToTable("Customers");

        // By convention, a property named Id or <type name>Id will be configured as the primary key of an entity.
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=fluent-api#configuring-a-primary-key
        // By convention, on relational databases primary keys are created with the name PK_<type name>. 
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations#primary-key-name
        //builder.HasKey(x => x.Id).HasName("PK_Customers");

        // By convention, when using a relational database, entity properties are mapped to table columns having the same name as the property.
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt#column-names
        builder.Property(x => x.Id).HasColumnName("CustomerId");

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

        // One to Many Relationship
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
        //builder.HasMany(c => c.Orders).WithOne(o => o.Customer).HasForeignKey(o => o.CustomerId).HasConstraintName("FK_Orders_Customers_CustomerId");

    }
}