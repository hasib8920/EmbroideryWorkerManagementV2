using System.ComponentModel.DataAnnotations;

namespace EmbroideryWorkerManagement.Models
{
    public class Holiday
    {
        public int Id { get; set; }

        [Required]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Reason { get; set; }
    }
}
