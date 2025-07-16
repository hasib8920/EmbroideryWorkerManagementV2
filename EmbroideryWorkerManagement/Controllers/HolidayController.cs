//using EmbroideryWorkerManagement.Data;
using EmbroideryWorkerManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class HolidayController : Controller
    {
        private readonly AppDbContext _context;

        public HolidayController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var holidays = await _context.Holidays
                .Include(h => h.Worker)
                .OrderByDescending(h => h.Date)
                .ToListAsync();
            return View(holidays);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var holiday = await _context.Holidays
                .Include(h => h.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (holiday == null) return NotFound();

            return View(holiday);
        }

        public IActionResult Create()
        {
            LoadWorkers();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Holiday holiday)
        {
            if (ModelState.IsValid)
            {
                _context.Add(holiday);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            LoadWorkers();
            return View(holiday);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var holiday = await _context.Holidays.FindAsync(id);
            if (holiday == null) return NotFound();

            LoadWorkers();
            return View(holiday);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Holiday holiday)
        {
            if (id != holiday.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(holiday);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HolidayExists(holiday.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            LoadWorkers();
            return View(holiday);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var holiday = await _context.Holidays
                .Include(h => h.Worker)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (holiday == null) return NotFound();

            return View(holiday);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var holiday = await _context.Holidays.FindAsync(id);
            if (holiday != null)
            {
                _context.Holidays.Remove(holiday);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool HolidayExists(int id)
        {
            return _context.Holidays.Any(e => e.Id == id);
        }

        private void LoadWorkers()
        {
            ViewBag.WorkerId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Workers, "Id", "Name");
        }
    }
}
