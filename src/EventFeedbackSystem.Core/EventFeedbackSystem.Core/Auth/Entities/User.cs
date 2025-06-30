using EventFeedbackSystem.Core.Shared;

namespace EventFeedbackSystem.Core.Auth.Entities;

public class User : Entity<long>
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public User(string email, string hashPasswords)
    {
        Email = email;
        PasswordHash = hashPasswords;   
    }

    //for add migrantion
    public User()
    {
    }
}
