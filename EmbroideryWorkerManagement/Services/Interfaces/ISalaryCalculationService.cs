using EmbroideryWorkerManagement.Models;

namespace EmbroideryWorkerManagement.Services
{
    public interface ISalaryCalculationService
    {
        MonthlyPayment Calculate(int workerId, int month, int year);
    }
}
