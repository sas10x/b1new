using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class BindEmployeeAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Answers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_EmployeeId",
                table: "Answers",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Employees_EmployeeId",
                table: "Answers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Employees_EmployeeId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_EmployeeId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Answers");
        }
    }
}
