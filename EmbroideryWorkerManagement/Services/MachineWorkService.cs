using EmbroideryWorkerManagement.Interfaces;
using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.Services.Interfaces;

namespace EmbroideryWorkerManagement.Services
{
    public class MachineWorkService : IMachineWorkService
    {
        private readonly IRepository<MachineWork> _repo;

        public MachineWorkService(IRepository<MachineWork> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<MachineWork>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<MachineWork?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AddAsync(MachineWork work) => await _repo.AddAsync(work);
        public async Task UpdateAsync(MachineWork work) => await _repo.UpdateAsync(work);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }

}
