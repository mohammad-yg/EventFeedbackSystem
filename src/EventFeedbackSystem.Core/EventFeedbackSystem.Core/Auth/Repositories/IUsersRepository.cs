using EventFeedbackSystem.Core.Auth.Entities;
using EventFeedbackSystem.Core.Shared;
using EventFeedbackSystem.Shared;

namespace EventFeedbackSystem.Core.Auth.Repositories;

public interface IUsersRepository : IRepository<User, long>
{
    User? GetByEmail(string email);
    Task<User?> GetByEmailAsync(string email);
}
