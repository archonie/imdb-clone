using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.User.Validators;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Users.Requests.Commands;
using ImdbClone.Application.Responses;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Users.Handlers.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {        
        var response = new BaseCommandResponse();
        var validator = new CreateUserDtoValidator();
        var validationResult = await validator.ValidateAsync(request.UserDto);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        var user = _mapper.Map<User>(request.UserDto);
        user = await _userRepository.Add(user);
        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = user.Id;
        return response;
    }
}