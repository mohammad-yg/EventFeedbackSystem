using EventFeedbackSystem.Application.Shared.Auth;
using EventFeedbackSystem.Application.Shared.Auth.Dtos;
using EventFeedbackSystem.Application.Shared.Shared;
using EventFeedbackSystem.Core.Auth.Entities;
using EventFeedbackSystem.Core.Auth.Repositories;
using EventFeedbackSystem.Core.Shared.Exceptions;

namespace EventFeedbackSystem.Application.Auth;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUsersRepository _usersRepository;
    private readonly ITokenService _tokenService;

    public AuthenticationService(IUsersRepository usersRepository, ITokenService tokenService)
    {
        _usersRepository = usersRepository;
        _tokenService = tokenService;
    }

    public async Task<ServiceResult<UserLoginOutputDto>> LoginAsync(UserLoginInput input)
    {
        var user = await _usersRepository.GetByEmailAsync(input.Email);

        if (user is null || !PasswordHelper.VerifyPassword(input.Password, user.PasswordHash))
            return new ServiceResult<UserLoginOutputDto>(false, null, "InvalidUsernameOrPassword");

        var token = _tokenService.GenerateToken(user);

        return new ServiceResult<UserLoginOutputDto>(true, new UserLoginOutputDto
        {
            Email = user.Email,
            Token = token
        });
    }

    public async Task<ServiceResult> RegisterAsyn(UserRegisterInput input)
    {
        var passwordHash = PasswordHelper.HashPassword(input.Password);
        var user = new User(input.Email, passwordHash);

        try
        {
            await _usersRepository.AddAsync(user);
            return new ServiceResult(true);
        }
        catch (InfrastructureException exception)
        {
            if(exception.Message == InfrastructureException.Messages.DuplicateRow)
                return new ServiceResult(false, "Email already exists");
        }

        throw new Exception();
    }
}