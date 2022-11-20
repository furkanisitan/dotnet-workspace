using DotNetWorkspace.EFCore.DataAccess.Configurations.Common;
using DotNetWorkspace.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.DataAccess.Configurations;

internal class OrderConfiguration : EntityDateConfiguration<Order, int>
{
    public override string TableName => "Orders";

    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        // @see https://docs.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt#precision-and-scale
        builder.Property(x => x.TotalPrice).HasPrecision(18, 2);

        // One to One Relationship - Different PK and FK
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
        //builder.HasOne(o => o.Payment).WithOne(p => p.Order).HasForeignKey<Payment>(p => p.OrderId).HasConstraintName("FK_Payments_Orders_OrderId");

        // One to One Relationship - Same PK and FK
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
        builder.HasOne(o => o.Payment).WithOne(p => p.Order).HasForeignKey<Payment>(p => p.Id).HasConstraintName("FK_Payments_Orders_Id")
            // @see https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#cascade-delete
            .OnDelete(DeleteBehavior.Cascade);

        // Many to Many Relationship
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#many-to-many
        //builder.HasMany(o => o.Products).WithMany(p => p.Orders).UsingEntity<Dictionary<string, object>>(
        //    "ProductOrder",
        //    j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId").HasConstraintName("FK_ProductOrder_Products_ProductId"),
        //    j => j.HasOne<Order>().WithMany().HasForeignKey("OrderId").HasConstraintName("FK_ProductOrder_Orders_OrderId"),
        //    j => {
        //        j.HasKey("ProductId", "OrderId").HasName("PK_ProductOrder_ProductId_OrderId");
        //        j.HasIndex("ProductId").HasDatabaseName("IX_ProductOrder_ProductId");
        //        j.HasIndex("OrderId").HasDatabaseName("IX_ProductOrder_OrderId");
        //    });

        // One to Many Relationship
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
        //builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId).HasConstraintName($"FK_Orders_Customers_CustomerId");

        // By convention, on relational databases indexes for foreign keys are created with the name IX_<type name>_<FK_Column>. 
        builder.HasIndex(x => x.CustomerId).HasDatabaseName("IX_Orders_CustomerId");
    }
}