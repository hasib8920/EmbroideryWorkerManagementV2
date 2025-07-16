using EmbroideryWorkerManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Services
{
    public class AutoSalaryGenerator
    {
        private readonly AppDbContext _context;

        public AutoSalaryGenerator(AppDbContext context)
        {
            _context = context;
        }

        public void GenerateMonthlySalary(int year, int month)
        {
            var workers = _context.Workers
                .Include(w => w.Attendances)
                .Include(w => w.MachineWorks)
                .Include(w => w.AdvanceSalaries)
                .Include(w => w.MonthlyTargets)
                .ToList();

            foreach (var worker in workers)
            {
                // Check already generated
                bool exists = _context.MonthlyPayments
                    .Any(p => p.WorkerId == worker.Id && p.Year == year && p.Month == month);
                if (exists)
                    continue;

                // Attendance Calculation
                var attendances = worker.Attendances
                    .Where(a => a.Date.Year == year && a.Date.Month == month)
                    .ToList();

                int totalWorkingDays = DateTime.DaysInMonth(year, month);
                int presentDays = attendances.Count(a => a.IsPresent);
                bool fullAttendance = (presentDays == totalWorkingDays);
                decimal attendanceBonus = fullAttendance ? 800 : 0;

                // Target Calculation
                var target = worker.MonthlyTargets.FirstOrDefault(t => t.Month == month && t.Year == year);
                decimal extraBonus = 0;
                if (target != null)
                {
                    foreach (var work in attendances)
                    {
                        if (work.UnitsProduced > target.DailyTargetUnits)
                        {
                            int extraUnits = work.UnitsProduced - target.DailyTargetUnits;
                            extraBonus += extraUnits * target.BonusPerExtraUnit;
                        }
                    }
                }

                // Advance Deduction
                var advances = worker.AdvanceSalaries
                    .Where(a => a.Date.Year == year && a.Date.Month == month)
                    .Sum(a => a.Amount);

                // Total Salary
                decimal totalSalary = worker.BaseSalary + attendanceBonus + extraBonus - advances;

                // Save Record
                var monthlyPayment = new MonthlyPayment
                {
                    WorkerId = worker.Id,
                    Year = year,
                    Month = month,
                    BaseSalary = worker.BaseSalary,
                    AttendanceBonus = attendanceBonus,
                    ExtraProductionBonus = extraBonus,
                    AdvanceDeduction = advances,
                    TotalSalary = totalSalary,
                    PaidAmount = 0,
                    DueAmount = totalSalary,
                    PaymentDate = DateTime.Now
                };

                _context.MonthlyPayments.Add(monthlyPayment);
            }

            _context.SaveChanges();
        }
    }
}
