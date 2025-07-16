using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class SalaryReportController : Controller
    {
        private readonly AppDbContext _context;

        public SalaryReportController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SalarySummary()
        {
            var salaries = _context.MonthlyPayments
                .Include(p => p.Worker)
                .OrderByDescending(p => p.Year).ThenByDescending(p => p.Month)
                .ToList();

            return View(salaries);
        }

        public IActionResult AdvanceSummary()
        {
            var advances = _context.AdvanceSalaries
                .Include(a => a.Worker)
                .OrderByDescending(a => a.Date)
                .ToList();

            return View(advances);
        }

        public IActionResult PaymentHistory()
        {
            var payments = _context.Payments
                .Include(p => p.MonthlyPayment)
                .ThenInclude(mp => mp.Worker)
                .OrderByDescending(p => p.PaymentDate)
                .ToList();

            return View(payments);
        }

        public IActionResult WorkerPaymentHistory(int workerId)
        {
            var worker = _context.Workers
                .Include(w => w.MonthlyPayments)
                .FirstOrDefault(w => w.Id == workerId);

            if (worker == null) return NotFound();

            return View(worker);
        }
        public IActionResult Filter(int? month, int? year, int? workerId)
        {
            var payments = _context.MonthlyPayments.Include(m => m.Worker).AsQueryable();

            if (month.HasValue)
                payments = payments.Where(x => x.Month == month);

            if (year.HasValue)
                payments = payments.Where(x => x.Year == year);

            if (workerId.HasValue)
                payments = payments.Where(x => x.WorkerId == workerId);

            var filterVM = new ReportFilterViewModel
            {
                Month = month,
                Year = year,
                WorkerId = workerId,
                Workers = _context.Workers.ToList()
            };

            ViewBag.Filter = filterVM;
            return View("SalarySummary", payments.ToList());
        }

    }
}
