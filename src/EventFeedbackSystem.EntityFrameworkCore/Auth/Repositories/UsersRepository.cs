using EventFeedbackSystem.Core.Auth.Entities;
using EventFeedbackSystem.Core.Auth.Repositories;

namespace EventFeedbackSystem.EntityFrameworkCore.Auth.Repositories;

public class UsersRepository : Repository<User, long>, IUsersRepository
{
    protected readonly DbSet<User> _table;
    protected readonly AppDbContext _context;
    public UsersRepository(AppDbContext context) : base (context)
    {
        _context = context;
        _table = _context.Users;
    }
    public User? GetByEmail(string email)
    {
        return _table.FirstOrDefault(e => e.Email == email);
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return _table.FirstOrDefaultAsync(e => e.Email == email);
    }
}
