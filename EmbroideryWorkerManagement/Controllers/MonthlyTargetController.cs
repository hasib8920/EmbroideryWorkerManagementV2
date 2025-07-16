//using EmbroideryWorkerManagement.Data;
using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class MonthlyTargetController : Controller
    {
        private readonly AppDbContext _context;

        public MonthlyTargetController(AppDbContext context)
        {
            _context = context;
        }

        private MonthlyTargetViewModel MapToViewModel(MonthlyTarget target)
        {
            return new MonthlyTargetViewModel
            {
                Id = target.Id,
                WorkerId = target.WorkerId,
                //WorkerName = target.Worker?.Name,
                Month = target.Month,
                Year = target.Year,
                DailyTargetUnits = target.DailyTargetUnits,
                TargetUnits = target.TargetUnits,
                BonusPerExtraUnit = target.BonusPerExtraUnit,
                DailyTargetBonusAmount = target.DailyTargetBonusAmount,
                FullAttendanceBonus = target.FullAttendanceBonus
            };
        }

        private MonthlyTarget MapToEntity(MonthlyTargetViewModel vm)
        {
            return new MonthlyTarget
            {
                Id = vm.Id,
                WorkerId = vm.WorkerId,
                Month = vm.Month,
                Year = vm.Year,
                DailyTargetUnits = vm.DailyTargetUnits,
                TargetUnits = vm.TargetUnits,
                BonusPerExtraUnit = vm.BonusPerExtraUnit,
                DailyTargetBonusAmount = vm.DailyTargetBonusAmount,
                FullAttendanceBonus = vm.FullAttendanceBonus
            };
        }

        public async Task<IActionResult> Index()
        {
            var targets = await _context.MonthlyTargets.Include(m => m.Worker).ToListAsync();
            var vmList = targets.Select(MapToViewModel).ToList();
            return View(vmList);
        }

        public IActionResult Create()
        {
            ViewBag.Workers = new SelectList(_context.Workers, "Id", "Name");
            return View(new MonthlyTargetViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MonthlyTargetViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var entity = MapToEntity(vm);
                _context.MonthlyTargets.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Workers = new SelectList(_context.Workers, "Id", "Name");
            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _context.MonthlyTargets.FindAsync(id);
            if (entity == null) return NotFound();

            ViewBag.Workers = new SelectList(_context.Workers, "Id", "Name");
            return View(MapToViewModel(entity));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MonthlyTargetViewModel vm)
        {
            if (id != vm.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var entity = MapToEntity(vm);
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Workers = new SelectList(_context.Workers, "Id", "Name");
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _context.MonthlyTargets.Include(m => m.Worker).FirstOrDefaultAsync(m => m.Id == id);
            if (entity == null) return NotFound();

            return View(MapToViewModel(entity));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.MonthlyTargets.Include(m => m.Worker).FirstOrDefaultAsync(m => m.Id == id);
            if (entity == null) return NotFound();

            return View(MapToViewModel(entity));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _context.MonthlyTargets.FindAsync(id);
            if (entity != null)
            {
                _context.MonthlyTargets.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
