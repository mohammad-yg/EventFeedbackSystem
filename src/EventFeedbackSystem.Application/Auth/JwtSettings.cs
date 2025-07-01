namespace EventFeedbackSystem.Application.Auth;

public class JwtSettings
{
    public string Secret { get; set; }
    public int ExpiryInHours { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}