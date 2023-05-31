using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace UserProfileService
{
    public class UsersManager : IUsersManager
    {
        private readonly UsersContext _dbContext;
        public UsersManager(UsersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CheckRegistration(LoginRequest loginRequest)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == loginRequest.Email);
            if (user == null) 
            {
                var a = 1;
                if (loginRequest.Password.Clone == user.Password.Clone)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<User> CreateUser(CreateUserRequest createUserRequest)
        {
            User newUser = new User { Name = createUserRequest.UserName, Email = createUserRequest.Email, RegistrationDate = DateTime.Now, Password = createUserRequest.Password };
            var userWithThisEmail = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == newUser.Email);
            if (userWithThisEmail == null)
            {
                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();
                return newUser;
            }
            else return null;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault((x => x.Id == id));
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            else return null;
        }

        public async Task<List<User>> Get()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.Select(x => new User { Id = x.Id, Name = x.Name, Email = x.Email, Password = x.Password }).ToList();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                return new User { Id = user.Id, Name = user.Name, Email = user.Email, Password = user.Password };
            }
            else
                return null;

        }
    }
}
