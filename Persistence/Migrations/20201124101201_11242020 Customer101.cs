using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class _11242020Customer101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Customers_CustomerId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_CustomerId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Visits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Visits_CustomerId",
                table: "Visits",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Customers_CustomerId",
                table: "Visits",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
