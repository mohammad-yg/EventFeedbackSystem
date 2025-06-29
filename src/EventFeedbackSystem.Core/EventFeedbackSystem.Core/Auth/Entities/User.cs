using EventFeedbackSystem.Core.Shared;

namespace EventFeedbackSystem.Core.Auth.Entities;

public class User : Entity<long>
{
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }

    public User(string email, string hashPasswords)
    {
        Email = email;
        PasswordHash = hashPasswords;   
    }
}
