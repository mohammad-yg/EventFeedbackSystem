namespace EventFeedbackSystem.Application.Auth;

public static class PasswordHelper
{
    private const int WorkFactor = 12;

    /// <summary>
    /// Hash password by BCrypt with automatic salt generation
    /// </summary>
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
    }

    /// <summary>
    /// Verify a password against a hashed password using BCrypt
    /// </summary>
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        try
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        catch
        {
            return false;
        }
    }
}