using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.User;
using ImdbClone.Application.Features.Users.Requests.Queries;
using MediatR;

namespace ImdbClone.Application.Features.Users.Handlers.Queries;

public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserListRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll();
        return _mapper.Map<List<UserDto>>(users);
    }
}