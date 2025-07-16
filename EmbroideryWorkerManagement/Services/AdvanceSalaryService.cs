using EmbroideryWorkerManagement.Interfaces;
using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.Services.Interfaces;

namespace EmbroideryWorkerManagement.Services
{
    public class AdvanceSalaryService : IAdvanceSalaryService
    {
        private readonly IRepository<AdvanceSalary> _repo;

        public AdvanceSalaryService(IRepository<AdvanceSalary> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<AdvanceSalary>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<AdvanceSalary?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AddAsync(AdvanceSalary salary) => await _repo.AddAsync(salary);
        public async Task UpdateAsync(AdvanceSalary salary) => await _repo.UpdateAsync(salary);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }

}
