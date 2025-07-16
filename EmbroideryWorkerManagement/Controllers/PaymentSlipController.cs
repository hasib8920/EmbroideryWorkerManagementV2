using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class PaymentSlipController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PaymentSlipPdfService _pdfService;

        public PaymentSlipController(AppDbContext context, PaymentSlipPdfService pdfService)
        {
            _context = context;
            _pdfService = pdfService;
        }

        public IActionResult DownloadPdf(int id)
        {
            var payment = _context.MonthlyPayments
                .Include(m => m.Worker)
                .FirstOrDefault(m => m.Id == id);

            if (payment == null) return NotFound();

            var pdfBytes = _pdfService.GeneratePdf(payment);
            return File(pdfBytes, "application/pdf", $"PaymentSlip_{payment.Worker.Name}_{payment.Month}_{payment.Year}.pdf");
        }
        public PaymentSlipController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var payments = _context.MonthlyPayments.Include(m => m.Worker).ToList();
            return View(payments);
        }

        public IActionResult GenerateSlip(int id)
        {
            var payment = _context.MonthlyPayments
                .Include(m => m.Worker)
                .FirstOrDefault(m => m.Id == id);

            if (payment == null) return NotFound();

            return View(payment);
        }
    }
}
