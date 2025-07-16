using EmbroideryWorkerManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class PaymentController : Controller
    {
        private readonly AppDbContext _context;

        public PaymentController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var payments = await _context.Payments
                .Include(p => p.MonthlyPayment)
                .ThenInclude(m => m.Worker)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
            return View(payments);
        }

        public async Task<IActionResult> SelectMonthlyPayment()
        {
            var monthlyPayments = await _context.MonthlyPayments
                .Include(m => m.Worker)
                .OrderByDescending(m => m.Year)
                .ThenByDescending(m => m.Month)
                .ToListAsync();

            return View(monthlyPayments);
        }

        // Create Payment Form
        public async Task<IActionResult> Create(int monthlyPaymentId)
        {
            var monthlyPayment = await _context.MonthlyPayments
                .Include(m => m.Worker)
                .FirstOrDefaultAsync(m => m.Id == monthlyPaymentId);

            if (monthlyPayment == null)
                return NotFound();

            ViewBag.MonthlyPayment = monthlyPayment;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int monthlyPaymentId, decimal paidAmount)
        {
            var monthlyPayment = await _context.MonthlyPayments
                .Include(m => m.Worker)
                .FirstOrDefaultAsync(m => m.Id == monthlyPaymentId);

            if (monthlyPayment == null)
                return NotFound();

            if (paidAmount <= 0 || paidAmount > monthlyPayment.DueAmount)
            {
                ModelState.AddModelError("", "Invalid payment amount.");
                ViewBag.MonthlyPayment = monthlyPayment;
                return View();
            }

            var payment = new Payment
            {
                MonthlyPaymentId = monthlyPaymentId,
                PaidAmount = paidAmount,
                PaymentDate = DateTime.Now
            };

            monthlyPayment.PaidAmount += paidAmount;
            monthlyPayment.DueAmount = monthlyPayment.TotalSalary - monthlyPayment.PaidAmount;

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Optional Details
        public async Task<IActionResult> Details(int id)
        {
            var payment = await _context.Payments
                .Include(p => p.MonthlyPayment)
                .ThenInclude(m => m.Worker)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (payment == null) return NotFound();

            return View(payment);
        }
    }
}
