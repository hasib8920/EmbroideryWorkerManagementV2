using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class MonthlyPaymentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISalaryCalculationService _salaryService;

        public MonthlyPaymentController(AppDbContext context, ISalaryCalculationService salaryService)
        {
            _context = context;
            _salaryService = salaryService;
        }

        public IActionResult Index()
        {
            var payments = _context.MonthlyPayments.Include(m => m.Worker).ToList();
            return View(payments);
        }

        public IActionResult Generate()
        {
            ViewBag.Workers = _context.Workers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Generate(int workerId, int month, int year)
        {
            var result = _salaryService.Calculate(workerId, month, year);

            _context.MonthlyPayments.Add(result);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
