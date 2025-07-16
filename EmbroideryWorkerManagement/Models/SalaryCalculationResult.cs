using EmbroideryWorkerManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace EmbroideryWorkerManagement.Models
{
    public class SalaryCalculationResult
    {
        public int Id { get; set; }
        public string WorkerName { get; set; }
        [Precision(18, 2)]

        public decimal BaseSalary { get; set; }
        public int TotalPresentDays { get; set; }
        [Precision(18, 2)]

        public decimal MealAllowance { get; set; }
        [Precision(18, 2)]

        public decimal FullAttendanceBonus { get; set; }
        public int TargetMetDays { get; set; }
        [Precision(18, 2)]

        public decimal DailyTargetBonus { get; set; }
        public int ExtraUnits { get; set; }
        [Precision(18, 2)]

        public decimal ExtraUnitBonus { get; set; }
        [Precision(18, 2)]

        public decimal TotalAdvanceDeduction { get; set; }
        [Precision(18, 2)]

        public decimal FinalSalary { get; set; }
    }
}
