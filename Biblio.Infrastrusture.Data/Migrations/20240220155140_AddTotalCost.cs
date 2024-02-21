using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblio.Infrastrusture.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                table: "BiblioLendingInfos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "BiblioLendingInfos");
        }
    }
}
