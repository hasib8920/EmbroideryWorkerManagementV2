using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmbroideryWorkerManagement.Migrations
{
    /// <inheritdoc />
    public partial class D2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineWorks_Attendances_AttendanceId",
                table: "MachineWorks");

            migrationBuilder.DropIndex(
                name: "IX_MachineWorks_AttendanceId",
                table: "MachineWorks");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "AttendanceId",
                table: "MachineWorks");

            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "MachineWorks");

            migrationBuilder.RenameColumn(
                name: "TargetBonus",
                table: "MonthlyPayments",
                newName: "PaidAmount");

            migrationBuilder.RenameColumn(
                name: "OvertimeAmount",
                table: "MonthlyPayments",
                newName: "ExtraProductionBonus");

            migrationBuilder.RenameColumn(
                name: "MealAllowance",
                table: "MonthlyPayments",
                newName: "DueAmount");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Workers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "BonusPerExtraUnit",
                table: "Workers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DailyTargetBonusAmount",
                table: "Workers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DailyTargetUnit",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MealAllowancePerDay",
                table: "Workers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AttendanceBonus",
                table: "MonthlyPayments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "MonthlyPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitsProduced",
                table: "MachineWorks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UnitsProduced",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OvertimeHours",
                table: "Attendances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MealAllowance",
                table: "Attendances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthlyPaymentId = table.Column<int>(type: "int", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_MonthlyPayments_MonthlyPaymentId",
                        column: x => x.MonthlyPaymentId,
                        principalTable: "MonthlyPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MonthlyPaymentId",
                table: "Payments",
                column: "MonthlyPaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropColumn(
                name: "BonusPerExtraUnit",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "DailyTargetBonusAmount",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "DailyTargetUnit",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "MealAllowancePerDay",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "AttendanceBonus",
                table: "MonthlyPayments");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "MonthlyPayments");

            migrationBuilder.RenameColumn(
                name: "PaidAmount",
                table: "MonthlyPayments",
                newName: "TargetBonus");

            migrationBuilder.RenameColumn(
                name: "ExtraProductionBonus",
                table: "MonthlyPayments",
                newName: "OvertimeAmount");

            migrationBuilder.RenameColumn(
                name: "DueAmount",
                table: "MonthlyPayments",
                newName: "MealAllowance");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UnitsProduced",
                table: "MachineWorks",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "AttendanceId",
                table: "MachineWorks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HoursWorked",
                table: "MachineWorks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "UnitsProduced",
                table: "Attendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "OvertimeHours",
                table: "Attendances",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MealAllowance",
                table: "Attendances",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_MachineWorks_AttendanceId",
                table: "MachineWorks",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineWorks_Attendances_AttendanceId",
                table: "MachineWorks",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "Id");
        }
    }
}
