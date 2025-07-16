using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class AdvanceSalaryController : Controller
    {
        private readonly AppDbContext _context;

        public AdvanceSalaryController(AppDbContext context)
        {
            _context = context;
        }

        // Index
        public async Task<IActionResult> Index()
        {
            var salaries = await _context.AdvanceSalaries
                .Include(a => a.Worker)
                .OrderByDescending(a => a.Date)
                .ToListAsync();

            return View(salaries);
        }

        // Create GET
        public IActionResult Create()
        {
            ViewBag.Workers = _context.Workers.ToList();
            return View(new AdvanceSalaryViewModel());
        }

        // Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvanceSalaryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var entity = new AdvanceSalary
                {
                    WorkerId = vm.WorkerId,
                    Date = vm.Date,
                    Amount = vm.Amount
                };

                _context.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Workers = _context.Workers.ToList();
            return View(vm);
        }

        // Edit GET
        public async Task<IActionResult> Edit(int id)
        {
            var salary = await _context.AdvanceSalaries.FindAsync(id);
            if (salary == null) return NotFound();

            var vm = new AdvanceSalaryViewModel
            {
                Id = salary.Id,
                WorkerId = salary.WorkerId,
                Date = salary.Date,
                Amount = salary.Amount
            };

            ViewBag.Workers = _context.Workers.ToList();
            return View(vm);
        }

        // Edit POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdvanceSalaryViewModel vm)
        {
            if (id != vm.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var entity = await _context.AdvanceSalaries.FindAsync(id);
                if (entity == null) return NotFound();

                entity.WorkerId = vm.WorkerId;
                entity.Date = vm.Date;
                entity.Amount = vm.Amount;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Workers = _context.Workers.ToList();
            return View(vm);
        }

        // Details
        public async Task<IActionResult> Details(int id)
        {
            var salary = await _context.AdvanceSalaries
                .Include(a => a.Worker)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (salary == null) return NotFound();

            return View(salary);
        }

        // Delete GET
        public async Task<IActionResult> Delete(int id)
        {
            var salary = await _context.AdvanceSalaries
                .Include(a => a.Worker)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (salary == null) return NotFound();

            return View(salary);
        }

        // Delete POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salary = await _context.AdvanceSalaries.FindAsync(id);
            if (salary != null)
            {
                _context.AdvanceSalaries.Remove(salary);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
