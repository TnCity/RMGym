using Microsoft.EntityFrameworkCore;
using RMGym.Data;
using RMGym.Models;

namespace RMGym.BLL
{
    public class UserRepository
    {
        private readonly GymDbContext _context;

        public UserRepository(GymDbContext context)
        {
            _context = context;
        }


        //Register User
        public async Task RegisterUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }


        // check mailId exixt or not?
        public async Task<bool> EmailExist(string email)
        {
            return await _context.Users.AnyAsync(E => E.Email == email);
        }

        //validate User
        public async Task<User?> ValidateUser(string email, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && 
                                    u.Password == password && 
                                    u.IsActive);
        }


        //get all users
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }


        //get user by Id
        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == user.UserId);

            if (existingUser == null)
            {
                throw new Exception(
                    $"User not found. UserId = {user.UserId}");
            }

            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;

            await _context.SaveChangesAsync();
        }

        public async Task ChangePassword(int userId, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                user.Password = newPassword;
                await _context.SaveChangesAsync();
            }
        }
    }

    
}