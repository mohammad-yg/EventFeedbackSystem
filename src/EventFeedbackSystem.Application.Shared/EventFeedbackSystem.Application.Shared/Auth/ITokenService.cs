using EventFeedbackSystem.Core.Auth.Entities;

namespace EventFeedbackSystem.Application.Shared.Auth;

public interface ITokenService
{
    string GenerateToken(User user);
    bool ValidateToken(string token);
}