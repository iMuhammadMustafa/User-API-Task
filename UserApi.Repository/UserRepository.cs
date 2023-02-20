using Microsoft.EntityFrameworkCore;
using User_API.Domain;

namespace User_API.UserApi.Repository
{
    public interface IUserRepository
    {
        public Task<User> GetUserById(string id);
        public Task<User> AddUser(User newUser);
    }
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> AddUser(User newUser)
        {
            await _appDbContext.Users.AddAsync(newUser);
            await _appDbContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> GetUserById(string id)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }
    }
}
