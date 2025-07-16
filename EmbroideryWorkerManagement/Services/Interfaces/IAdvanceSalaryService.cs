using EmbroideryWorkerManagement.Models;

namespace EmbroideryWorkerManagement.Services.Interfaces
{
    public interface IAdvanceSalaryService
    {
        Task<IEnumerable<AdvanceSalary>> GetAllAsync();
        Task<AdvanceSalary?> GetByIdAsync(int id);
        Task AddAsync(AdvanceSalary salary);
        Task UpdateAsync(AdvanceSalary salary);
        Task DeleteAsync(int id);
    }

}
