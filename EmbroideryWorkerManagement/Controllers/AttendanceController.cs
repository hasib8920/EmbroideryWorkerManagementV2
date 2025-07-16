using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly AppDbContext _context;

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var attendances = await _context.Attendances
                .Include(a => a.Worker)
                .ToListAsync();

            return View(attendances);
        }

        public IActionResult Create()
        {
            PopulateWorkers();
            return View(new AttendanceCreateEditViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttendanceCreateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var attendance = new Attendance
                {
                    WorkerId = model.WorkerId,
                    Date = model.Date,
                    IsPresent = model.IsPresent,
                    MealAllowance = model.MealAllowance
                };

                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateWorkers();
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null) return NotFound();

            var model = new AttendanceCreateEditViewModel
            {
                Id = attendance.Id,
                WorkerId = attendance.WorkerId,
                Date = attendance.Date,
                IsPresent = attendance.IsPresent,
                MealAllowance = attendance.MealAllowance
            };

            PopulateWorkers();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AttendanceCreateEditViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var attendance = await _context.Attendances.FindAsync(id);
                    attendance.WorkerId = model.WorkerId;
                    attendance.Date = model.Date;
                    attendance.IsPresent = model.IsPresent;
                    attendance.MealAllowance = model.MealAllowance;

                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(model.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateWorkers();
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var attendance = await _context.Attendances
                .Include(a => a.Worker)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (attendance == null) return NotFound();

            return View(attendance);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var attendance = await _context.Attendances
                .Include(a => a.Worker)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (attendance == null) return NotFound();

            return View(attendance);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
            return _context.Attendances.Any(e => e.Id == id);
        }

        private void PopulateWorkers()
        {
            ViewBag.WorkerId = new SelectList(_context.Workers, "Id", "Name");
        }
    }
}
