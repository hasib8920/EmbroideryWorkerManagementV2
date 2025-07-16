using System.ComponentModel.DataAnnotations;

namespace EmbroideryWorkerManagement.Models
{
    public class Worker
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal BaseSalary { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal OvertimeRate { get; set; }

        [Required]
        public string NationalIdNumber { get; set; }

        public string NIDImagePath { get; set; } = "N/A";

        public string Address { get; set; }

        public bool IsActive { get; set; } = true;

        [Required, Range(0, double.MaxValue)]
        public int DailyTargetUnit { get; set; } = 300000;

        [Required, Range(0, double.MaxValue)]
        public decimal DailyTargetBonusAmount { get; set; } = 1;

        [Required, Range(0, double.MaxValue)]
        public decimal BonusPerExtraUnit { get; set; } = 0.02M;

        [Required, Range(0, double.MaxValue)]
        public decimal MealAllowancePerDay { get; set; } = 50;

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<MachineWork> MachineWorks { get; set; } = new List<MachineWork>();
        public ICollection<AdvanceSalary> AdvanceSalaries { get; set; } = new List<AdvanceSalary>();
        public ICollection<MonthlyPayment> MonthlyPayments { get; set; } = new List<MonthlyPayment>();
        public ICollection<MonthlyTarget> MonthlyTargets { get; set; } = new List<MonthlyTarget>();
    }

}
