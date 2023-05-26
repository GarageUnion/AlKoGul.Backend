namespace UserProfileService
{
    public interface IUsersManager
    {
        Task<List<User>> Get();
        Task<User> GetById(int id);
        Task<User> CreateUser(CreateUserRequest createUserRequest);
        Task<User> DeleteUser(int id);
    }
}
