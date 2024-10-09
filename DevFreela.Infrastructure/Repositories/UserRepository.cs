using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DevFreela.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DevFreelaDbContext _context;
    public UserRepository(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll()
    {
        var users = await _context.Users
            .Where(u => !u.IsDeleted).ToListAsync();
        
        return users;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return (await _context.Users.SingleOrDefaultAsync(u => u.Id == id))!;
    }

    public async Task<User?> GetById(int id)
    {
        return await _context.Users
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<int> Add(User user)
    {
        await _context.Users.AddAsync(user);
        _context.SaveChanges();

        return user.Id;
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        return await _context
            .Users
            .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash) ?? throw new InvalidOperationException();
    }
}