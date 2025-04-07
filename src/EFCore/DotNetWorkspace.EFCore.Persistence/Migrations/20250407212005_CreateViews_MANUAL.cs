using DotNetWorkspace.EFCore.Persistence.EntityConfigurations.Views;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetWorkspace.EFCore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateViews_MANUAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ProductOrdersCountEntityConfiguration.Up(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ProductOrdersCountEntityConfiguration.Down(migrationBuilder);
        }
    }
}
