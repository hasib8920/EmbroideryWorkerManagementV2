using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class SalaryGenerateController : Controller
    {
        private readonly AppDbContext _context;
        private readonly AutoSalaryGenerator _salaryGenerator;

        public SalaryGenerateController(AppDbContext context, AutoSalaryGenerator salaryGenerator)
        {
            _context = context;
            _salaryGenerator = salaryGenerator;
        }

        // GET: Salary Generate Form
        public IActionResult Index()
        {
            return View();
        }

        // POST: Salary Generate Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Generate(int year, int month)
        {
            if (year < 2000 || year > 2100 || month < 1 || month > 12)
            {
                TempData["Error"] = "Invalid Year or Month.";
                return RedirectToAction(nameof(Index));
            }

            _salaryGenerator.GenerateMonthlySalary(year, month);
            TempData["Success"] = "Salary generated successfully!";
            return RedirectToAction(nameof(Index));
        }

        // Salary Summary Report (optional)
        public IActionResult MonthlySummary(int year, int month)
        {
            var payments = _context.MonthlyPayments
                .Include(m => m.Worker)
                .Where(m => m.Year == year && m.Month == month)
                .ToList();

            ViewBag.Year = year;
            ViewBag.Month = month;

            return View(payments);
        }
    }
}
