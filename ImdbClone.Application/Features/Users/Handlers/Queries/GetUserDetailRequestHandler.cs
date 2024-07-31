using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.User;
using ImdbClone.Application.Features.Users.Requests.Queries;
using MediatR;

namespace ImdbClone.Application.Features.Users.Handlers.Queries;

public class GetUserDetailRequestHandler : IRequestHandler<GetUserDetailRequest, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserDetailRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserDto> Handle(GetUserDetailRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id);
        return _mapper.Map<UserDto>(user);
    }
}