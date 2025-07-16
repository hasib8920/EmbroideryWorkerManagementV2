using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Models
{
    public class MonthlyTarget
    {
        public int Id { get; set; }

        [Required]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        [Range(1, 12)]
        public int Month { get; set; }

        [Range(2000, 2100)]
        public int Year { get; set; }

        [Range(0, int.MaxValue)]
        public int DailyTargetUnits { get; set; }

        [Range(0, int.MaxValue)]
        public int TargetUnits { get; set; }

        [Precision(18, 2)]
        [Range(0, double.MaxValue)]
        public decimal BonusPerExtraUnit { get; set; }

        [Precision(18, 2)]
        [Range(0, double.MaxValue)]
        public decimal DailyTargetBonusAmount { get; set; }

        [Precision(18, 2)]
        [Range(0, double.MaxValue)]
        public decimal FullAttendanceBonus { get; set; }
    }
}
