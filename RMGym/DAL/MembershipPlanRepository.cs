using Microsoft.EntityFrameworkCore;
using RMGym.Data;
using RMGym.Models;

namespace RMGym.DAL
{
    public class MembershipPlanRepository
    {
        private readonly GymDbContext _context;

        public MembershipPlanRepository(GymDbContext context)
        {
            _context = context;
        }


        // Get All Plans
        public async Task<List<MembershipPlan>> GetAllMembershipPlans()
        {
            return await _context.MembershipPlans.ToListAsync();
        }

        // Get Plan By Id
        public async Task<MembershipPlan?> GetMembershipPlanById(int id)
        {
            return await _context.MembershipPlans
                .FirstOrDefaultAsync(p => p.PlanId == id);
        }

        // Add Plan
        public async Task AddMembershipPlan(MembershipPlan plan)
        {
            _context.MembershipPlans.Add(plan);
            await _context.SaveChangesAsync();
        }

        // Update Plan
        public async Task UpdateMembershipPlan(MembershipPlan plan)
        {
            _context.MembershipPlans.Update(plan);
            await _context.SaveChangesAsync();
        }

        // Delete Plan
        public async Task DeleteMembershipPlan(int id)
        {
            var plan = await _context.MembershipPlans.FindAsync(id);

            if (plan != null)
            {
                _context.MembershipPlans.Remove(plan);
                await _context.SaveChangesAsync();
            }
        }
    }
}