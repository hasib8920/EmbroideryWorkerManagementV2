using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmbroideryWorkerManagement.Controllers
{
    public class MachineWorkController : Controller
    {
        private readonly AppDbContext _context;

        public MachineWorkController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.MachineWorks.Include(m => m.Worker).ToListAsync();

            var viewModel = data.Select(m => new MachineWorkViewModel
            {
                Id = m.Id,
                WorkerId = m.WorkerId,
                WorkerName = m.Worker.Name,
                Date = m.Date,
                UnitsProduced = m.UnitsProduced
            }).ToList();

            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Workers = _context.Workers.ToList();
            return View(new MachineWorkViewModel { Date = DateTime.Today });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MachineWorkViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var entity = new MachineWork
                {
                    WorkerId = vm.WorkerId,
                    Date = vm.Date,
                    UnitsProduced = vm.UnitsProduced
                };
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Workers = _context.Workers.ToList();
            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _context.MachineWorks.FindAsync(id);
            if (entity == null) return NotFound();

            var vm = new MachineWorkViewModel
            {
                Id = entity.Id,
                WorkerId = entity.WorkerId,
                Date = entity.Date,
                UnitsProduced = entity.UnitsProduced
            };

            ViewBag.Workers = _context.Workers.ToList();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MachineWorkViewModel vm)
        {
            if (id != vm.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var entity = await _context.MachineWorks.FindAsync(id);
                if (entity == null) return NotFound();

                entity.WorkerId = vm.WorkerId;
                entity.Date = vm.Date;
                entity.UnitsProduced = vm.UnitsProduced;

                _context.Update(entity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Workers = _context.Workers.ToList();
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _context.MachineWorks.Include(m => m.Worker).FirstOrDefaultAsync(m => m.Id == id);
            if (entity == null) return NotFound();

            var vm = new MachineWorkViewModel
            {
                Id = entity.Id,
                WorkerId = entity.WorkerId,
                WorkerName = entity.Worker.Name,
                Date = entity.Date,
                UnitsProduced = entity.UnitsProduced
            };

            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.MachineWorks.Include(m => m.Worker).FirstOrDefaultAsync(m => m.Id == id);
            if (entity == null) return NotFound();

            var vm = new MachineWorkViewModel
            {
                Id = entity.Id,
                WorkerId = entity.WorkerId,
                WorkerName = entity.Worker.Name,
                Date = entity.Date,
                UnitsProduced = entity.UnitsProduced
            };

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _context.MachineWorks.FindAsync(id);
            if (entity != null)
            {
                _context.MachineWorks.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
