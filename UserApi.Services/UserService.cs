using User_API.Domain;
using User_API.UserApi.Domain.DTOs;
using User_API.UserApi.Repository;

namespace User_API.UserApi.Services
{
    public interface IUserService
    {
        public PostUserDTO AddUser(User newUser);
        public UserDTO GetUserById(string id);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public PostUserDTO AddUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
