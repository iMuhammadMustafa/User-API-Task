using AutoMapper;
using User_API.Domain;
using User_API.UserApi.Domain.DTOs;
using User_API.UserApi.Repository;

namespace User_API.UserApi.Services
{
    public interface IUserService
    {
        public Task<NewUserResponseDTO> AddUser(NewUserDTO newUser);
        public Task<UserDTO> GetUserById(string id);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IAuthenticationService authenticationService,  IMapper mapper)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        public async Task<NewUserResponseDTO> AddUser(NewUserDTO newUser)
        {
            var user = _mapper.Map<User>(newUser);
            user.Id = _authenticationService.HashUserId(newUser.Email);

            var createduser = await _userRepository.AddUser(user);
            var accessToken = _authenticationService.GenerateJWToken(createduser.Id);

            var response = new NewUserResponseDTO()
            {
                Id = createduser.Id,
                AccessToken = accessToken
            };

            return response;
            
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await _userRepository.GetUserById(id);

            return _mapper.Map<UserDTO>(user);
        }
    }
}
