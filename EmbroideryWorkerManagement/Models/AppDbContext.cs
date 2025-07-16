using Microsoft.EntityFrameworkCore;
using EmbroideryWorkerManagement.Models;
namespace EmbroideryWorkerManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        //public DbSet<OvertimePolicy> OvertimePolicies { get; set; }
        public DbSet<AdvanceSalary> AdvanceSalaries { get; set; }
        public DbSet<MonthlyTarget> MonthlyTargets { get; set; }
        public DbSet<MachineWork> MachineWorks { get; set; }
        public DbSet<SalaryCalculationResult> salaryCalculationResults { get; set; }
        public DbSet<MonthlyPayment> MonthlyPayments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MonthlyPaymentHistory> MonthlyPaymentHistories { get; set; }

    }
}