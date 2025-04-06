using DotNetWorkspace.EFCore.Persistence.Entities;
using DotNetWorkspace.EFCore.Persistence.Entities.Joins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.Persistence.EntityConfigurations.Joins;

internal static class OrderProductEntityConfiguration
{
    public static Func<EntityTypeBuilder<OrderProduct>, ReferenceCollectionBuilder<Product, OrderProduct>>
        Right = x => x
            .HasOne(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);

    public static Func<EntityTypeBuilder<OrderProduct>, ReferenceCollectionBuilder<Order, OrderProduct>>
        Left = x => x
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

    public static Action<EntityTypeBuilder<OrderProduct>> Join = x =>
    {
        x.ToTable("OrderProduct");
        x.HasKey(op => new { op.OrderId, op.ProductId });
    };
}