using System.ComponentModel.DataAnnotations;
using EmbroideryWorkerManagement.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
namespace EmbroideryWorkerManagement.Models
{
    public class AdvanceSalary
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }

}
