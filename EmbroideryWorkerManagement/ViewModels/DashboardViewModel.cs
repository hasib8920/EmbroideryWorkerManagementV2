using EmbroideryWorkerManagement.Models;
using System.Collections.Generic;

namespace EmbroideryWorkerManagement.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalWorkers { get; set; }
        public int TotalAttendance { get; set; }
        public int TotalOvertimeHours { get; set; }
        public decimal TotalPayment { get; set; }

        public List<MonthlyPaymentSummary> MonthlyPayments { get; set; }
    }

    public class MonthlyPaymentSummary
    {
        public string MonthYear { get; set; }
        public decimal TotalPayment { get; set; }
    }

}
