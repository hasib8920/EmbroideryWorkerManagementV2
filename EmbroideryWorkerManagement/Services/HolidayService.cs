using EmbroideryWorkerManagement.Interfaces;
using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.Services.Interfaces;

namespace EmbroideryWorkerManagement.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IRepository<Holiday> _repo;

        public HolidayService(IRepository<Holiday> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Holiday>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Holiday?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AddAsync(Holiday holiday) => await _repo.AddAsync(holiday);
        public async Task UpdateAsync(Holiday holiday) => await _repo.UpdateAsync(holiday);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }

}
