using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EmbroideryWorkerManagement.ViewModels
{
    public class MachineWorkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Worker is required.")]
        public int WorkerId { get; set; }

        [ValidateNever]
        public string WorkerName { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Units Produced is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Units Produced must be a positive number.")]
        public int UnitsProduced { get; set; }
    }
}
