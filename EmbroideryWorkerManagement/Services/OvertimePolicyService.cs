//using EmbroideryWorkerManagement.Interfaces;
//using EmbroideryWorkerManagement.Models;
//using EmbroideryWorkerManagement.Services.Interfaces;

//namespace EmbroideryWorkerManagement.Services
//{
//    public class OvertimePolicyService : IOvertimePolicyService
//    {
//        private readonly IRepository<OvertimePolicy> _repo;

//        public OvertimePolicyService(IRepository<OvertimePolicy> repo)
//        {
//            _repo = repo;
//        }

//        public async Task<IEnumerable<OvertimePolicy>> GetAllAsync() => await _repo.GetAllAsync();
//        public async Task<OvertimePolicy?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
//        public async Task AddAsync(OvertimePolicy policy) => await _repo.AddAsync(policy);
//        public async Task UpdateAsync(OvertimePolicy policy) => await _repo.UpdateAsync(policy);
//        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
//    }

//}
