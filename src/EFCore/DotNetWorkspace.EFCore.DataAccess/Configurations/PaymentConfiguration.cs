using DotNetWorkspace.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.DataAccess.Configurations;

internal class PaymentConfiguration : EntityDateConfiguration<Payment, int>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.CardNumber).HasMaxLength(20);

        // Check Constraints
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/indexes?tabs=fluent-api#check-constraints
        builder.HasCheckConstraint("CK_Payments_Status_Enum", "[PaymentStatus] IN (0, 1, 2, 3, 4)");
    }
}