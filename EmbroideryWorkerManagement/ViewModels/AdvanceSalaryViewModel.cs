using System.ComponentModel.DataAnnotations;

namespace EmbroideryWorkerManagement.ViewModels
{
    public class AdvanceSalaryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Worker is required")]
        public int WorkerId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Amount is required")]
        [Range(1, 1000000, ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }
    }
}
