using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmbroideryWorkerManagement.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int MonthlyPaymentId { get; set; }
        public MonthlyPayment MonthlyPayment { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PaidAmount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }
    }

}
