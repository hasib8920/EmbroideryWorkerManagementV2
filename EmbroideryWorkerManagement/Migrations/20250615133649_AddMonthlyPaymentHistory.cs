using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmbroideryWorkerManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddMonthlyPaymentHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyPaymentHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthlyPaymentId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyPaymentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyPaymentHistories_MonthlyPayments_MonthlyPaymentId",
                        column: x => x.MonthlyPaymentId,
                        principalTable: "MonthlyPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPaymentHistories_MonthlyPaymentId",
                table: "MonthlyPaymentHistories",
                column: "MonthlyPaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyPaymentHistories");
        }
    }
}
