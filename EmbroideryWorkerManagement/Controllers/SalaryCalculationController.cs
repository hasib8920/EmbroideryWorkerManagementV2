using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class SalaryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISalaryCalculationService _salaryCalculationService;

        public SalaryController(AppDbContext context, ISalaryCalculationService salaryCalculationService)
        {
            _context = context;
            _salaryCalculationService = salaryCalculationService;
        }

        // Salary Calculation Form
        public IActionResult Calculate()
        {
            ViewBag.Workers = _context.Workers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(int workerId, int year, int month)
        {
            var payment = _salaryCalculationService.Calculate(workerId, year, month);

            // Check if already exists, prevent duplicate insertion
            var exists = _context.MonthlyPayments
                .Any(m => m.WorkerId == workerId && m.Year == year && m.Month == month);

            if (!exists)
            {
                _context.MonthlyPayments.Add(payment);
                _context.SaveChanges();
            }

            return RedirectToAction("Details", new { id = payment.Id });
        }

        // Salary Details View
        public IActionResult Details(int id)
        {
            var payment = _context.MonthlyPayments
                .Include(m => m.Worker)
                .FirstOrDefault(m => m.Id == id);

            if (payment == null)
                return NotFound();

            return View(payment);
        }
    }
}
