using EmbroideryWorkerManagement.Interfaces;
using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.Services.Interfaces;

namespace EmbroideryWorkerManagement.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IRepository<Worker> _workerRepository;

        public WorkerService(IRepository<Worker> workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public async Task<IEnumerable<Worker>> GetAllWorkersAsync()
            => await _workerRepository.GetAllAsync();

        public async Task<Worker?> GetWorkerByIdAsync(int id)
            => await _workerRepository.GetByIdAsync(id);

        public async Task AddWorkerAsync(Worker worker)
            => await _workerRepository.AddAsync(worker);

        public async Task UpdateWorkerAsync(Worker worker)
            => await _workerRepository.UpdateAsync(worker);

        public async Task DeleteWorkerAsync(int id)
            => await _workerRepository.DeleteAsync(id);
    }
}
