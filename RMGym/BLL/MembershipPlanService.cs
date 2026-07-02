using RMGym.DAL;
using RMGym.Models;

namespace RMGym.BLL
{
    public class MembershipPlanService
    {
        private readonly MembershipPlanRepository _repository;

        public MembershipPlanService(MembershipPlanRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MembershipPlan>> GetAllMembershipPlans()
        {
            return await _repository.GetAllMembershipPlans();
        }

        public async Task<MembershipPlan?> GetMembershipPlanById(int id)
        {
            return await _repository.GetMembershipPlanById(id);
        }

        public async Task AddMembershipPlan(MembershipPlan plan)
        {
            await _repository.AddMembershipPlan(plan);
        }

        public async Task UpdateMembershipPlan(MembershipPlan plan)
        {
            await _repository.UpdateMembershipPlan(plan);
        }

        public async Task DeleteMembershipPlan(int id)
        {
            await _repository.DeleteMembershipPlan(id);
        }
    }
}