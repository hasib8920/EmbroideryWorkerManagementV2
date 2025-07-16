using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmbroideryWorkerManagement.Migrations
{
    /// <inheritdoc />
    public partial class D1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "AdvanceSalaries");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "AdvanceSalaries");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "AdvanceSalaries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "AdvanceSalaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "AdvanceSalaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "AdvanceSalaries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
