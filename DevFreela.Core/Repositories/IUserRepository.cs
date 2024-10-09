using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> GetByIdAsync(int id);
    Task<int> Add(User user);
    Task Update(User user);

    Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);

}
