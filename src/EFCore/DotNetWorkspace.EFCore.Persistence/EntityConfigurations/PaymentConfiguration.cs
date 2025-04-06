using DotNetWorkspace.EFCore.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.Persistence.EntityConfigurations;

internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    private const string TableName = "Paymentsxxx";
    private const string PkColumnName = "PaymentId";

    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=fluent-api#table-name
        builder.ToTable(TableName);

        // @see https://docs.microsoft.com/en-us/ef/core/modeling/indexes?tabs=fluent-api#check-constraints
        // @see https://github.com/efcore/EFCore.CheckConstraints#enum-constraints
        builder.ToTable(x => x.HasCheckConstraint("CK_Payments_Status_Enum", "[Status] IN (0, 1, 2, 3, 4)"));

        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=fluent-api#configuring-a-primary-key
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations#primary-key-name
        builder.HasKey(x => x.Id).HasName($"PK_{TableName}_{PkColumnName}");

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#column-names
        builder.Property(x => x.Id).HasColumnName(PkColumnName);

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#maximum-length
        builder.Property(x => x.CardNumber).HasMaxLength(255);

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#precision-and-scale
        builder.Property(x => x.Amount).HasPrecision(18, 2);

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations#pre-defined-conversions
        builder.Property(x => x.Status).HasConversion<short>();

        // One-to-One relationship: One Payment (Dependent/Child) is associated with one Order (Principal/Parent)
        // @see https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-one#required-one-to-one
        builder
            .HasOne(p => p.Order)
            .WithOne(o => o.Payment)
            .HasForeignKey<Payment>(p => p.OrderId);
    }
}