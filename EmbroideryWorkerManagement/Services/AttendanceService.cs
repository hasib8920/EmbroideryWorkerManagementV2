using EmbroideryWorkerManagement.Interfaces;
using EmbroideryWorkerManagement.Models;
using EmbroideryWorkerManagement.Services.Interfaces;

namespace EmbroideryWorkerManagement.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IRepository<Attendance> _repo;

        public AttendanceService(IRepository<Attendance> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Attendance?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AddAsync(Attendance attendance) => await _repo.AddAsync(attendance);
        public async Task UpdateAsync(Attendance attendance) => await _repo.UpdateAsync(attendance);
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }

}
