using DotNetWorkspace.EFCore.Persistence.Entities;
using DotNetWorkspace.EFCore.Persistence.EntityConfigurations.Joins;
using DotNetWorkspace.EFCore.Persistence.EntityConfigurations.Owned;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.Persistence.EntityConfigurations;

internal class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    private const string TableName = "Orders";
    private const string PkColumnName = "OrderId";

    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=fluent-api#table-name
        builder.ToTable(TableName);

        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=fluent-api#configuring-a-primary-key
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations#primary-key-name
        builder.HasKey(x => x.Id).HasName($"PK_{TableName}_{PkColumnName}");

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#column-names
        builder.Property(x => x.Id).HasColumnName(PkColumnName);

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#precision-and-scale
        builder.Property(x => x.TotalPrice).HasPrecision(18, 2);
        builder.Property(x => x.DiscountAmount).HasPrecision(18, 2);

        // Owned Entity: Address is an owned entity of Order
        // @see https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities
        builder.OwnsOne(o => o.Address, AddressEntityConfiguration.ForOrder);

        // One-to-Many relationship: One Customer (Principal/Parent) can have many Orders (Dependent/Child)
        // @see https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-many#required-one-to-many
        builder
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);


        // Many-to-Many relationship: Many Orders can have many Products
        // @see https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many#many-to-many-with-navigations-to-join-entity
        builder
            .HasMany(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity(
                OrderProductEntityConfiguration.Right,
                OrderProductEntityConfiguration.Left,
                OrderProductEntityConfiguration.Join);
    }
}