using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblio.Infrastrusture.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFineReason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FineReason",
                table: "BiblioFines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FineReason",
                table: "BiblioFines");
        }
    }
}
