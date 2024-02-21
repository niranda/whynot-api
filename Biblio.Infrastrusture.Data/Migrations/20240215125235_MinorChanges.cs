using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblio.Infrastrusture.Data.Migrations
{
    /// <inheritdoc />
    public partial class MinorChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiblioFines_BiblioBooks_BookId",
                table: "BiblioFines");

            migrationBuilder.DropForeignKey(
                name: "FK_BiblioFines_BiblioReaders_ReaderId",
                table: "BiblioFines");

            migrationBuilder.DropIndex(
                name: "IX_BiblioFines_ReaderId",
                table: "BiblioFines");

            migrationBuilder.DropColumn(
                name: "PayBeforeDate",
                table: "BiblioFines");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "BiblioLendingInfos",
                newName: "DateIssued");

            migrationBuilder.RenameColumn(
                name: "ReaderId",
                table: "BiblioFines",
                newName: "LendingInfoId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BiblioFines",
                newName: "BiblioReaderId");

            migrationBuilder.RenameIndex(
                name: "IX_BiblioFines_BookId",
                table: "BiblioFines",
                newName: "IX_BiblioFines_BiblioReaderId");

            migrationBuilder.RenameColumn(
                name: "PledgeCost",
                table: "BiblioBooks",
                newName: "RentalCostPerDay");

            migrationBuilder.RenameColumn(
                name: "CostPerDay",
                table: "BiblioBooks",
                newName: "DepositAmount");

            migrationBuilder.AddColumn<Guid>(
                name: "FineId",
                table: "BiblioLendingInfos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BiblioFines_LendingInfoId",
                table: "BiblioFines",
                column: "LendingInfoId",
                unique: true,
                filter: "[LendingInfoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BiblioFines_BiblioLendingInfos_LendingInfoId",
                table: "BiblioFines",
                column: "LendingInfoId",
                principalTable: "BiblioLendingInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BiblioFines_BiblioReaders_BiblioReaderId",
                table: "BiblioFines",
                column: "BiblioReaderId",
                principalTable: "BiblioReaders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiblioFines_BiblioLendingInfos_LendingInfoId",
                table: "BiblioFines");

            migrationBuilder.DropForeignKey(
                name: "FK_BiblioFines_BiblioReaders_BiblioReaderId",
                table: "BiblioFines");

            migrationBuilder.DropIndex(
                name: "IX_BiblioFines_LendingInfoId",
                table: "BiblioFines");

            migrationBuilder.DropColumn(
                name: "FineId",
                table: "BiblioLendingInfos");

            migrationBuilder.RenameColumn(
                name: "DateIssued",
                table: "BiblioLendingInfos",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "LendingInfoId",
                table: "BiblioFines",
                newName: "ReaderId");

            migrationBuilder.RenameColumn(
                name: "BiblioReaderId",
                table: "BiblioFines",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BiblioFines_BiblioReaderId",
                table: "BiblioFines",
                newName: "IX_BiblioFines_BookId");

            migrationBuilder.RenameColumn(
                name: "RentalCostPerDay",
                table: "BiblioBooks",
                newName: "PledgeCost");

            migrationBuilder.RenameColumn(
                name: "DepositAmount",
                table: "BiblioBooks",
                newName: "CostPerDay");

            migrationBuilder.AddColumn<DateTime>(
                name: "PayBeforeDate",
                table: "BiblioFines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_BiblioFines_ReaderId",
                table: "BiblioFines",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BiblioFines_BiblioBooks_BookId",
                table: "BiblioFines",
                column: "BookId",
                principalTable: "BiblioBooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BiblioFines_BiblioReaders_ReaderId",
                table: "BiblioFines",
                column: "ReaderId",
                principalTable: "BiblioReaders",
                principalColumn: "Id");
        }
    }
}
