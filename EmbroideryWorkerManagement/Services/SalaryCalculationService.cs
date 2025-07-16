using EmbroideryWorkerManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Services
{
    public class SalaryCalculationService : ISalaryCalculationService
    {
        private readonly AppDbContext _context;

        public SalaryCalculationService(AppDbContext context)
        {
            _context = context;
        }

        public MonthlyPayment Calculate(int workerId, int month, int year)
        {
            var worker = _context.Workers.FirstOrDefault(w => w.Id == workerId);
            if (worker == null) throw new Exception("Worker not found");

            var attendances = _context.Attendances
                .Where(a => a.WorkerId == workerId && a.Date.Year == year && a.Date.Month == month)
                .ToList();

            var machineWorks = _context.MachineWorks
                .Where(m => m.WorkerId == workerId && m.Date.Year == year && m.Date.Month == month)
                .ToList();

            var advances = _context.AdvanceSalaries
                .Where(a => a.WorkerId == workerId && a.Date.Year == year && a.Date.Month == month)
                .Sum(a => a.Amount);

            var monthlyTarget = _context.MonthlyTargets
                .FirstOrDefault(t => t.WorkerId == workerId && t.Year == year && t.Month == month);

            int totalDaysInMonth = DateTime.DaysInMonth(year, month);
            int presentDays = attendances.Count(a => a.IsPresent);
            bool fullAttendance = (presentDays == totalDaysInMonth);

            decimal attendanceBonus = 0;
            if (monthlyTarget != null && fullAttendance)
            {
                attendanceBonus = monthlyTarget.FullAttendanceBonus;
            }

            decimal extraProductionBonus = 0;
            if (monthlyTarget != null)
            {
                int totalUnitsProduced = machineWorks.Sum(m => (int)m.UnitsProduced);
                int extraUnits = totalUnitsProduced - monthlyTarget.TargetUnits;
                if (extraUnits > 0)
                {
                    extraProductionBonus = extraUnits * monthlyTarget.BonusPerExtraUnit;
                }
            }

            decimal totalSalary = worker.BaseSalary + attendanceBonus + extraProductionBonus - advances;

            var monthlyPayment = new MonthlyPayment
            {
                WorkerId = workerId,
                Year = year,
                Month = month,
                BaseSalary = worker.BaseSalary,
                AttendanceBonus = attendanceBonus,
                ExtraProductionBonus = extraProductionBonus,
                AdvanceDeduction = advances,
                TotalSalary = totalSalary,
                PaidAmount = 0,
                DueAmount = totalSalary,
                PaymentDate = DateTime.Now
            };

            return monthlyPayment;
        }
    }
}
