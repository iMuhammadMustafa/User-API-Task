using User_API.UserApi.Domain.DTOs;

namespace User_API.UserApi.Services
{
    public interface IAuthenticationService
    {
        public Task<NewUserResponseDTO> GenerateJWToken();
    }
    public class AuthenticationService : IAuthenticationService
    {
        public Task<NewUserResponseDTO> GenerateJWToken()
        {
            throw new NotImplementedException();
        }
    }
}
