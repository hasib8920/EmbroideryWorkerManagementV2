using EmbroideryWorkerManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Services
{
    public class MonthlyPaymentService
    {
        private readonly AppDbContext _context;

        public MonthlyPaymentService(AppDbContext context)
        {
            _context = context;
        }

        public void GenerateMonthlyPayments(int year, int month)
        {
            var workers = _context.Workers.Include(w => w.MonthlyTargets).ToList();

            foreach (var worker in workers)
            {
                // Check already exists
                if (_context.MonthlyPayments.Any(mp => mp.WorkerId == worker.Id && mp.Month == month && mp.Year == year))
                    continue;

                // Attendance Calculation
                var attendances = _context.Attendances
                    .Where(a => a.WorkerId == worker.Id && a.Date.Year == year && a.Date.Month == month)
                    .ToList();

                int totalDays = DateTime.DaysInMonth(year, month);
                int presentDays = attendances.Count(a => a.IsPresent);
                bool fullAttendance = (presentDays == totalDays);
                decimal attendanceBonus = fullAttendance ? 800 : 0;

                // Advance Deduction
                var advances = _context.AdvanceSalaries
                    .Where(a => a.WorkerId == worker.Id && a.Date.Year == year && a.Date.Month == month)
                    .Sum(a => a.Amount);

                // Machine Work Bonus Calculation
                var target = _context.MonthlyTargets.FirstOrDefault(mt => mt.WorkerId == worker.Id && mt.Month == month && mt.Year == year);
                decimal extraBonus = 0;

                if (target != null)
                {
                    var works = _context.MachineWorks
                        .Where(m => m.WorkerId == worker.Id && m.Date.Year == year && m.Date.Month == month)
                        .ToList();

                    foreach (var work in works)
                    {
                        if (work.UnitsProduced > target.DailyTargetUnits)
                        {
                            int extraUnits = (int)(work.UnitsProduced - target.DailyTargetUnits);
                            extraBonus += extraUnits * target.BonusPerExtraUnit;
                        }
                    }

                    // Add Daily Target Bonus
                    extraBonus += presentDays * target.DailyTargetBonusAmount;
                    if (fullAttendance)
                        extraBonus += target.FullAttendanceBonus;
                }

                var totalSalary = worker.BaseSalary + attendanceBonus + extraBonus - advances;

                var monthlyPayment = new MonthlyPayment
                {
                    WorkerId = worker.Id,
                    Month = month,
                    Year = year,
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
