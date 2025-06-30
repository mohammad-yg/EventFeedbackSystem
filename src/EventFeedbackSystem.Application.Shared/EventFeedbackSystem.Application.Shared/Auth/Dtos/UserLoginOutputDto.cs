namespace EventFeedbackSystem.Application.Shared.Auth.Dtos;

public record UserLoginOutputDto
{
    public string Token { get; set; }
    public string Email { get; set; }
}
