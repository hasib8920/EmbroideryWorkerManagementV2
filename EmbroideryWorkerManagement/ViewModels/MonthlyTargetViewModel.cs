using System.ComponentModel.DataAnnotations;

namespace EmbroideryWorkerManagement.ViewModels
{
    public class MonthlyTargetViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Worker is required")]
        public int WorkerId { get; set; }

        //public string WorkerName { get; set; }

        [Range(1, 12, ErrorMessage = "Month must be between 1 and 12")]
        public int Month { get; set; }

        [Range(2000, 2100, ErrorMessage = "Year must be valid")]
        public int Year { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Daily target must be positive")]
        public int DailyTargetUnits { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Target Units must be positive")]
        public int TargetUnits { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Bonus must be positive")]
        public decimal BonusPerExtraUnit { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Daily Bonus must be positive")]
        public decimal DailyTargetBonusAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Full Attendance Bonus must be positive")]
        public decimal FullAttendanceBonus { get; set; }
    }
}
