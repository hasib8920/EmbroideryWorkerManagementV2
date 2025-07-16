using System.ComponentModel.DataAnnotations;

namespace EmbroideryWorkerManagement.Models
{
    public class MonthlyPayment
    {
        public int Id { get; set; }

        [Required]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        [Range(1, 12)]
        public int Month { get; set; }

        [Range(2000, 2100)]
        public int Year { get; set; }

        public decimal BaseSalary { get; set; }
        public decimal AttendanceBonus { get; set; }
        public decimal ExtraProductionBonus { get; set; }
        public decimal AdvanceDeduction { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
