using LibraryManagementApi.Repositories.Interface;
using LibraryManagementApi.Services.Interface;

namespace LibraryManagementApi.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Models.User? GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }
        public Models.User? GetUserByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }
        public void RegisterUser(Models.User user)
        {
            _userRepository.Add(user);
        }
        public Models.User? Login(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }
    }
}