using EmbroideryWorkerManagement.Models;

namespace EmbroideryWorkerManagement.Services.Interfaces
{
    public interface IHolidayService
    {
        Task<IEnumerable<Holiday>> GetAllAsync();
        Task<Holiday?> GetByIdAsync(int id);
        Task AddAsync(Holiday holiday);
        Task UpdateAsync(Holiday holiday);
        Task DeleteAsync(int id);
    }

}
