//using EmbroideryWorkerManagement.Models;
//using Microsoft.EntityFrameworkCore;

//namespace EmbroideryWorkerManagement.Services
//{
//    public class MonthlyPaymentCalculation
//    {
//        private readonly AppDbContext _context;

//        public MonthlyPaymentCalculation(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<MonthlyPayment> Calculate(int workerId, int month, int year)
//        {
//            var worker = await _context.Workers
//                .Include(w => w.Attendances)
//                .Include(w => w.MachineWorks)
//                .FirstOrDefaultAsync(w => w.Id == workerId);

//            if (worker == null) return null;

//            var attendance = worker.Attendances
//                .Where(a => a.Date.Month == month && a.Date.Year == year)
//                .ToList();

//            int totalDaysPresent = attendance.Count;
//            decimal mealAllowance = attendance.Sum(a => (decimal)(a.MealAllowance ?? 0));
//            decimal overtimeHours = attendance.Sum(a => (decimal)(a.OvertimeHours ?? 0));
//            decimal holidayOvertimeHours = attendance.Where(a => a.IsHoliday).Sum(a => (decimal)(a.OvertimeHours ?? 0));
//            decimal normalOvertimeHours = overtimeHours - holidayOvertimeHours;

//            // Overtime Rate Calculation
//            decimal normalRate = await _context.OvertimePolicies
//                .Where(p => !p.IsHoliday)
//                .Select(p => (decimal?)p.RatePerHour)
//                .FirstOrDefaultAsync() ?? 0;

//            decimal holidayRate = await _context.OvertimePolicies
//                .Where(p => p.IsHoliday)
//                .Select(p => (decimal?)p.RatePerHour)
//                .FirstOrDefaultAsync() ?? 0;

//            decimal overtimePay = (normalOvertimeHours * normalRate) + (holidayOvertimeHours * holidayRate);

//            // Target Bonus Calculation
//            var monthlyTarget = await _context.MonthlyTargets
//                .FirstOrDefaultAsync(mt => mt.WorkerId == workerId && mt.Month == month && mt.Year == year);

//            decimal targetBonus = 0;

//            if (monthlyTarget != null)
//            {
//                int targetMetDays = attendance.Count(a => (a.UnitsProduced ?? 0) >= monthlyTarget.TargetUnits);
//                decimal dailyTargetBonus = targetMetDays * monthlyTarget.DailyTargetBonusAmount;

//                decimal fullAttendanceBonus = 0;
//                if (totalDaysPresent >= DateTime.DaysInMonth(year, month))
//                {
//                    fullAttendanceBonus = monthlyTarget.FullAttendanceBonus;
//                }

//                decimal extraUnits = attendance.Sum(a => (a.UnitsProduced ?? 0) > monthlyTarget.TargetUnits
//                                                        ? (a.UnitsProduced ?? 0) - monthlyTarget.TargetUnits
//                                                        : 0);
//                decimal extraBonus = extraUnits * monthlyTarget.BonusPerExtraUnit;

//                targetBonus = dailyTargetBonus + fullAttendanceBonus + extraBonus;
//            }

//            // Advance Deduction
//            decimal advanceDeduction = await _context.AdvanceSalaries
//                .Where(a => a.WorkerId == workerId && a.Date.Month == month && a.Date.Year == year)
//                .SumAsync(a => (decimal?)a.Amount) ?? 0;

//            // Final Total Salary
//            decimal totalSalary = worker.BaseSalary + mealAllowance + overtimePay + targetBonus;

//            var payment = new MonthlyPayment
//            {
//                WorkerId = workerId,
//                Month = month,
//                Year = year,
//                BaseSalary = worker.BaseSalary,
//                MealAllowance = mealAllowance,
//                OvertimeAmount = overtimePay,
//                TargetBonus = targetBonus,
//                AdvanceDeduction = advanceDeduction,
//                TotalSalary = totalSalary
//            };

//            return payment;
//        }
//    }
//}
