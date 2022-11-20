using DotNetWorkspace.EFCore.DataAccess.Configurations.Common;
using DotNetWorkspace.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;

namespace DotNetWorkspace.EFCore.DataAccess.Configurations;

internal class PaymentConfiguration : EntityDateConfiguration<Payment, int>
{
    private readonly ISqlGenerationHelper _sqlGenerationHelper;

    public PaymentConfiguration(ISqlGenerationHelper sqlGenerationHelper)
    {
        _sqlGenerationHelper = sqlGenerationHelper;
    }

    public override string TableName => "Payments";

    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);

        builder.ToTable(x =>
        {
            // Check Constraints
            // @see https://docs.microsoft.com/en-us/ef/core/modeling/indexes?tabs=fluent-api#check-constraints
            // @see https://github.com/efcore/EFCore.CheckConstraints#enum-constraints
            x.HasCheckConstraint("CK_Payments_Status_Enum", $"{_sqlGenerationHelper.DelimitIdentifier("Status")} IN (0, 1, 2, 3, 4)");
        });

        builder.Property(x => x.CardNumber).HasMaxLength(20);
    }
}