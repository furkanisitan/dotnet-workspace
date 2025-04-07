using DotNetWorkspace.EFCore.Persistence.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetWorkspace.EFCore.Persistence.EntityConfigurations.Views;

internal class ProductOrdersCountEntityConfiguration : IEntityTypeConfiguration<ProductOrdersCount>
{
    public void Configure(EntityTypeBuilder<ProductOrdersCount> builder)
    {
        // @see https://learn.microsoft.com/en-us/ef/core/modeling/keyless-entity-types?tabs=data-annotations#example
        builder.ToView("vProductOrdersCounts");
        builder.HasNoKey();
    }

    /// <summary>
    ///     <b>[IMPORTANT]</b> Add this script to migration manually.
    /// </summary>
    public static void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(
            """
            CREATE VIEW vProductOrdersCounts AS
            SELECT 
                p.ProductId,
                p.Name AS ProductName,
                COUNT(op.OrderId) AS OrderCount
            FROM Products p
            JOIN OrderProducts op ON p.ProductId = op.ProductId
            GROUP BY p.ProductId, p.Name;
            """
        );
    }

    /// <summary>
    ///     <b>[IMPORTANT]</b> Add this script to migration manually.
    /// </summary>
    public static void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DROP VIEW vProductOrdersCounts;");
    }
}