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
    }
}