using EmbroideryWorkerManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace EmbroideryWorkerManagement.Models
{
    public class SalaryCalculationResultViewModel
    {
        public int Id { get; set; }
        public string WorkerName { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        [Precision(18, 2)]

        public decimal BaseSalary { get; set; }
        [Precision(18, 2)]

        public decimal FullAttendanceBonus { get; set; }
        [Precision(18, 2)]

        public decimal DailyTargetBonus { get; set; }
        [Precision(18, 2)]

        public decimal ExtraUnitBonus { get; set; }
        [Precision(18, 2)]

        public decimal TotalMealAllowance { get; set; }
        [Precision(18, 2)]

        public decimal AdvanceDeduction { get; set; }
        [Precision(18, 2)]

        public decimal NetSalary { get; set; }
    }
}
