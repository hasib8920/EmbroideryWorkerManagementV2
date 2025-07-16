using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmbroideryWorkerManagement.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraBonus",
                table: "MonthlyPayments");

            migrationBuilder.DropColumn(
                name: "NetSalary",
                table: "MonthlyPayments");

            migrationBuilder.DropColumn(
                name: "MachineName",
                table: "MachineWorks");

            migrationBuilder.RenameColumn(
                name: "WorkDate",
                table: "MachineWorks",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Holidays",
                newName: "Reason");

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

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Holidays",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "MealAllowance",
                table: "Attendances",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.CreateIndex(
                name: "IX_MachineWorks_AttendanceId",
                table: "MachineWorks",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_WorkerId",
                table: "Holidays",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Workers_WorkerId",
                table: "Holidays",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineWorks_Attendances_AttendanceId",
                table: "MachineWorks",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Workers_WorkerId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineWorks_Attendances_AttendanceId",
                table: "MachineWorks");

            migrationBuilder.DropIndex(
                name: "IX_MachineWorks_AttendanceId",
                table: "MachineWorks");

            migrationBuilder.DropIndex(
                name: "IX_Holidays_WorkerId",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "AttendanceId",
                table: "MachineWorks");

            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "MachineWorks");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Holidays");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "MachineWorks",
                newName: "WorkDate");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "Holidays",
                newName: "Description");

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraBonus",
                table: "MonthlyPayments",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetSalary",
                table: "MonthlyPayments",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MachineName",
                table: "MachineWorks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MealAllowance",
                table: "Attendances",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
