using EmbroideryWorkerManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class WorkerController : Controller
    {
        private readonly AppDbContext _context;

        public WorkerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var workers = await _context.Workers.ToListAsync();
            return View(workers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Worker worker)
        {
            if (ModelState.IsValid)
            {
                worker.IsActive = true;
                _context.Workers.Add(worker);
                await _context.SaveChangesAsync();
                TempData["success"] = "Worker added successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(worker);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var worker = await _context.Workers.FindAsync(id);
            if (worker == null) return NotFound();

            return View(worker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Worker worker)
        {
            if (id != worker.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Workers.Update(worker);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Worker updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Workers.Any(e => e.Id == worker.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(worker);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var worker = await _context.Workers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (worker == null) return NotFound();

            return View(worker);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var worker = await _context.Workers.FindAsync(id);
            if (worker == null) return NotFound();

            return View(worker);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            if (worker != null)
            {
                _context.Workers.Remove(worker);
                await _context.SaveChangesAsync();
                TempData["success"] = "Worker deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
