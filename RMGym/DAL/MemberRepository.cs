using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RMGym.Data;
using RMGym.Models;

namespace RMGym.DAL
{
    public class MemberRepository
    {
        private readonly GymDbContext _context;
        private readonly IConfiguration _configuration;

        public MemberRepository(GymDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Get All Members
        public async Task<List<Member>> GetAllMembers()
        {
            return await _context.Members.ToListAsync();
        }
        // Get Member By Id
        public async Task<Member?> GetMemberById(int id)
        {
            return await _context.Members
                .FirstOrDefaultAsync(m => m.MembershipId == id);
        }
        public async Task<Member?> GetMemberByEmail(string email)
        {
            return await _context.Members
                .Where(x => x.Email == email)
                .OrderByDescending(x => x.MembershipId)
                .FirstOrDefaultAsync();
        }

        // Add Member
        public async Task AddMember(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }


        //------------------------------------
        //  Similer try with ADO.net.
        //------------------------------------


        //public async Task AddMember(Member member)
        //{
        //    var conStr = _configuration.GetConnectionString("DefaultConnection")
        //                 ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        //    using SqlConnection con = new SqlConnection(conStr);

        //    string query = @"INSERT INTO Members
        //                    (FullName, PhoneNumber, Email, Address, EmergencyContactNo, JoinDate, AssignedTrainer, IsActive)
        //                     VALUES
        //                    (@FullName, @PhoneNumber, @Email, @Address, @EmergencyContactNo, @JoinDate, @AssignedTrainer, @IsActive)";

        //    using SqlCommand cmd = new SqlCommand(query, con);

        //    cmd.Parameters.AddWithValue("@FullName", member.FullName);
        //    cmd.Parameters.AddWithValue("@PhoneNumber", member.PhoneNumber);
        //    cmd.Parameters.AddWithValue("@Email", member.Email);
        //    cmd.Parameters.AddWithValue("@Address", member.Address ?? "");
        //    cmd.Parameters.AddWithValue("@EmergencyContactNo", member.EmergencyContactNo);
        //    cmd.Parameters.AddWithValue("@JoinDate", member.JoinDate);
        //    cmd.Parameters.AddWithValue("@AssignedTrainer", member.AssignedTrainer ?? "");
        //    cmd.Parameters.AddWithValue("@IsActive", member.IsActive);

        //    await con.OpenAsync();
        //    await cmd.ExecuteNonQueryAsync();
        //}
        //-------------------------------------------------------------------------------------------------

                             // Update Member
        public async Task UpdateMember(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }

        // Delete Member
        public async Task DeleteMember(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }
    }
}
