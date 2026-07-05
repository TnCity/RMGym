using RMGym.DAL;
using RMGym.Models;

namespace RMGym.BLL
{
    public class MembershipSubscriptionService
    {
        private readonly MembershipSubscriptionRepository _repository;

        public MembershipSubscriptionService(
            MembershipSubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MembershipSubscription>> GetAllSubscriptions()
        {
            return await _repository.GetAllSubscriptions();
        }

        public async Task AddSubscription(MembershipSubscription subscription)
        {
            await _repository.AddSubscription(subscription);
        }

        public async Task<MembershipSubscription?> GetLatestSubscription(int memberId)
        {
            return await _repository.GetLatestSubscription(memberId);
        }
    }
}