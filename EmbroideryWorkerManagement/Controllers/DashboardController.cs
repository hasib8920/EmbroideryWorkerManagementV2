using EmbroideryWorkerManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var totalWorkers = _context.Workers.Count();
            var totalPayments = _context.Payments.Sum(p => p.PaidAmount);
            var totalAdvance = _context.AdvanceSalaries.Sum(a => a.Amount);
            var dueAmount = _context.MonthlyPayments.Sum(m => m.DueAmount);

            ViewBag.TotalWorkers = totalWorkers;
            ViewBag.TotalPayments = totalPayments;
            ViewBag.TotalAdvance = totalAdvance;
            ViewBag.TotalDue = dueAmount;

            return View();
        }
    }
}
