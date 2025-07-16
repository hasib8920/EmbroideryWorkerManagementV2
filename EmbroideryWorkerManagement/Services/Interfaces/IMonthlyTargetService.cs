using EmbroideryWorkerManagement.Models;

namespace EmbroideryWorkerManagement.Services.Interfaces
{
    public interface IMonthlyTargetService
    {
        Task<IEnumerable<MonthlyTarget>> GetAllAsync();
        Task<MonthlyTarget?> GetByIdAsync(int id);
        Task AddAsync(MonthlyTarget target);
        Task UpdateAsync(MonthlyTarget target);
        Task DeleteAsync(int id);
    }

}
