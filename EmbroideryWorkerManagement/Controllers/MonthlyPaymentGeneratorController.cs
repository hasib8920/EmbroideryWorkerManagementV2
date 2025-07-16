using EmbroideryWorkerManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmbroideryWorkerManagement.Controllers
{
    public class MonthlyPaymentGeneratorController : Controller
    {
        private readonly MonthlyPaymentService _paymentService;

        public MonthlyPaymentGeneratorController(MonthlyPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IActionResult Generate(int year, int month)
        {
            _paymentService.GenerateMonthlyPayments(year, month);
            TempData["Success"] = $"Payment for {month}/{year} generated successfully.";
            return RedirectToAction("Index", "PaymentSlip");
        }
    }
}
