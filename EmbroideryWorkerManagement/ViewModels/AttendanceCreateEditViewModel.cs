using System.ComponentModel.DataAnnotations;

namespace EmbroideryWorkerManagement.ViewModels
{
    public class AttendanceCreateEditViewModel
    {
        public int Id { get; set; } // For Edit

        [Required(ErrorMessage = "Worker is required")]
        public int WorkerId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Presence status is required")]
        public bool IsPresent { get; set; }

        [Required(ErrorMessage = "Meal Allowance is required")]
        [Range(0, double.MaxValue)]
        public decimal MealAllowance { get; set; }
    }
}
