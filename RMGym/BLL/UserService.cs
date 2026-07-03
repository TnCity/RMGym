using RMGym.Models;

namespace RMGym.BLL
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        
        public async Task RegisterUser(User user)
        {
            await _repository.RegisterUser(user);
        }
        public async Task<bool> EmailExist(string email)
        {
            return await _repository.EmailExist(email);
        }

        public async Task<User?> ValidateUser(string email, string password)
        {
            return await _repository.ValidateUser(email, password);
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _repository.GetAllUsers();
        }
        public async Task<User?> GetUserById(int id)
        {
            return await _repository.GetUserById(id);
        }
        public async Task UpdateUser(User user)
        {
            await _repository.UpdateUser(user);
        }

        public async Task ChangePassword(int userId, string newPassword)
        {
            await _repository.ChangePassword(userId, newPassword);
        }
    }
}
