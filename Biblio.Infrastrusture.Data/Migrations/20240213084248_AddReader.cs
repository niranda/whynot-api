using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblio.Infrastrusture.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiblioFines_AspNetUsers_UserId",
                table: "BiblioFines");

            migrationBuilder.DropForeignKey(
                name: "FK_BiblioLendingInfos_AspNetUsers_UserId",
                table: "BiblioLendingInfos");

            migrationBuilder.DropTable(
                name: "BiblioDiscounts");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BiblioLendingInfos",
                newName: "ReaderId");

            migrationBuilder.RenameIndex(
                name: "IX_BiblioLendingInfos_UserId",
                table: "BiblioLendingInfos",
                newName: "IX_BiblioLendingInfos_ReaderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BiblioFines",
                newName: "ReaderId");

            migrationBuilder.RenameIndex(
                name: "IX_BiblioFines_UserId",
                table: "BiblioFines",
                newName: "IX_BiblioFines_ReaderId");

            migrationBuilder.AddColumn<double>(
                name: "CostPerDay",
                table: "BiblioBooks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "BiblioBooks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "PledgeCost",
                table: "BiblioBooks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "BiblioReaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiblioReaders", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BiblioFines_BiblioReaders_ReaderId",
                table: "BiblioFines",
                column: "ReaderId",
                principalTable: "BiblioReaders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BiblioLendingInfos_BiblioReaders_ReaderId",
                table: "BiblioLendingInfos",
                column: "ReaderId",
                principalTable: "BiblioReaders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiblioFines_BiblioReaders_ReaderId",
                table: "BiblioFines");

            migrationBuilder.DropForeignKey(
                name: "FK_BiblioLendingInfos_BiblioReaders_ReaderId",
                table: "BiblioLendingInfos");

            migrationBuilder.DropTable(
                name: "BiblioReaders");

            migrationBuilder.DropColumn(
                name: "CostPerDay",
                table: "BiblioBooks");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "BiblioBooks");

            migrationBuilder.DropColumn(
                name: "PledgeCost",
                table: "BiblioBooks");

            migrationBuilder.RenameColumn(
                name: "ReaderId",
                table: "BiblioLendingInfos",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BiblioLendingInfos_ReaderId",
                table: "BiblioLendingInfos",
                newName: "IX_BiblioLendingInfos_UserId");

            migrationBuilder.RenameColumn(
                name: "ReaderId",
                table: "BiblioFines",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BiblioFines_ReaderId",
                table: "BiblioFines",
                newName: "IX_BiblioFines_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BiblioDiscounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiblioDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BiblioDiscounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiblioDiscounts_UserId",
                table: "BiblioDiscounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BiblioFines_AspNetUsers_UserId",
                table: "BiblioFines",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BiblioLendingInfos_AspNetUsers_UserId",
                table: "BiblioLendingInfos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
