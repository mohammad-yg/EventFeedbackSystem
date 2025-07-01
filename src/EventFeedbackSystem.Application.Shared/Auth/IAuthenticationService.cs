using EventFeedbackSystem.Application.Shared.Auth.Dtos;

namespace EventFeedbackSystem.Application.Shared.Auth;

public interface IAuthenticationService
{
    Task<ServiceResult> RegisterAsyn(UserRegisterInput input);
    Task<ServiceResult<UserLoginOutputDto>> LoginAsync(UserLoginInput input);
}
