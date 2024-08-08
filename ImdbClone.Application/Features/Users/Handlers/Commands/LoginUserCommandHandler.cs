using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.Features.Users.Requests.Commands;
using ImdbClone.Application.Responses;
using MediatR;

namespace ImdbClone.Application.Features.Users.Handlers.Commands;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
{
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;   
    }
    public async Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var getUser = await _userRepository.FindUserByEmail(request.LoginDto.Username);
        if (getUser == null)
        {
            return new LoginResponse(false, "User not found");
        }

        var checkPassword = BCrypt.Net.BCrypt.Verify(request.LoginDto.Password, getUser.Password);
        if (!checkPassword)
        {
            return new LoginResponse(false, "Password not correct");
        }

        return new LoginResponse(true, "Login successful", _userRepository.GenerateToken(getUser));
    }
}