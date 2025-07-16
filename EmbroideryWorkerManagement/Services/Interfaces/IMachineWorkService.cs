using EmbroideryWorkerManagement.Models;

namespace EmbroideryWorkerManagement.Services.Interfaces
{
    public interface IMachineWorkService
    {
        Task<IEnumerable<MachineWork>> GetAllAsync();
        Task<MachineWork?> GetByIdAsync(int id);
        Task AddAsync(MachineWork work);
        Task UpdateAsync(MachineWork work);
        Task DeleteAsync(int id);
    }

}
