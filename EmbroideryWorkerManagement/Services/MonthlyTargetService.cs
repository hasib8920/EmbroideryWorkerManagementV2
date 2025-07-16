using EmbroideryWorkerManagement.Interfaces;
using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.Services.Interfaces;

namespace EmbroideryWorkerManagement.Services
{
    public class MonthlyTargetService : IMonthlyTargetService
    {
        private readonly IRepository<MonthlyTarget> _repo;

        public MonthlyTargetService(IRepository<MonthlyTarget> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<MonthlyTarget>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<MonthlyTarget?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AddAsync(MonthlyTarget target) => await _repo.AddAsync(target);
        public async Task UpdateAsync(MonthlyTarget target) => await _repo.UpdateAsync(target);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }

}
