using Microsoft.EntityFrameworkCore;
using RMGym.Data;
using RMGym.Models;

namespace RMGym.DAL
{
    public class MembershipSubscriptionRepository
    {
        private readonly GymDbContext _context;

        public MembershipSubscriptionRepository(GymDbContext context)
        {
            _context = context;
        }

        public async Task<List<MembershipSubscription>> GetAllSubscriptions()
        {
            return await _context.MembershipSubscriptions
                .Include(x => x.Member)
                .Include(x => x.MembershipPlan)
                .ToListAsync();
        }

        public async Task AddSubscription(MembershipSubscription subscription)
        {
            _context.MembershipSubscriptions.Add(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task<MembershipSubscription?> GetLatestSubscription(int memberId)
        {
            return await _context.MembershipSubscriptions
                .Include(x => x.MembershipPlan)
                .Where(x => x.MemberId == memberId)
                .OrderByDescending(x => x.SubscriptionId)
                .FirstOrDefaultAsync();
        }
    }
}