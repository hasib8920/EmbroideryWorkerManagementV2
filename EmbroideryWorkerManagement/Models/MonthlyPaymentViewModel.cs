using System.ComponentModel.DataAnnotations;
using EmbroideryWorkerManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace EmbroideryWorkerManagement.Models
{
    public class MonthlyPaymentViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Worker")]
        public int WorkerId { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }
        [Precision(18, 2)]

        public decimal BaseSalary { get; set; }
        [Precision(18, 2)]

        public decimal OvertimeAmount { get; set; }
        [Precision(18, 2)]
        public decimal TargetBonus { get; set; }
        [Precision(18, 2)]

        public decimal ExtraBonus { get; set; }
        [Precision(18, 2)]

        public decimal MealAllowance { get; set; }
        [Precision(18, 2)]

        public decimal AdvanceDeduction { get; set; }
        [Precision(18, 2)]

        public decimal TotalSalary { get; set; }
        [Precision(18, 2)]

        public decimal NetSalary { get; set; }

        public string? WorkerName { get; set; }
    }
}
