using RMGym.DAL;
using RMGym.Models;

namespace RMGym.BLL
{
    public class MemberService
    {
        private readonly MemberRepository _repository;

        public MemberService(MemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Member>> GetAllMembers()
        {
            return await _repository.GetAllMembers();
        }

        public async Task<Member?> GetMemberById(int id)
        {
            return await _repository.GetMemberById(id);
        }

        public async Task<Member?> GetMemberByEmail(string email)
        {
            return await _repository.GetMemberByEmail(email);
        }

        public async Task AddMember(Member member)
        {
            await _repository.AddMember(member);
        }

        public async Task UpdateMember(Member member)
        {
            await _repository.UpdateMember(member);
        }

        public async Task DeleteMember(int id)
        {
            await _repository.DeleteMember(id);
        }
    }
}