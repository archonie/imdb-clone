using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.User.Validators;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Users.Requests.Commands;
using ImdbClone.Application.Responses;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Users.Handlers.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RegisterResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<RegisterResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        
        // var validator = new CreateUserDtoValidator();
        // var validationResult = await validator.ValidateAsync(request.UserDto);
        // if (!validationResult.IsValid)
        // {
        //     response.Success = false;
        //     response.Message = "Creation Failed";
        //     response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        // }
        var getUser = await _userRepository.FindUserByEmail(request.UserDto.Username);
        if (getUser != null)
        {
            return new RegisterResponse(false, "User already registered");
        }

        var user = new ApplicationUser
        {
            Username = request.UserDto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(request.UserDto.Password)
        };
        await _userRepository.Add(user);
        return new RegisterResponse(true, "User registered");
        
    }
}