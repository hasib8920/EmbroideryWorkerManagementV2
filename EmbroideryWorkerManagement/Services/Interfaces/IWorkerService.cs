using EmbroideryWorkerManagement.Models;

namespace EmbroideryWorkerManagement.Services.Interfaces
{
    public interface IWorkerService
    {
        Task<IEnumerable<Worker>> GetAllWorkersAsync();
        Task<Worker?> GetWorkerByIdAsync(int id);
        Task AddWorkerAsync(Worker worker);
        Task UpdateWorkerAsync(Worker worker);
        Task DeleteWorkerAsync(int id);
    }
}
