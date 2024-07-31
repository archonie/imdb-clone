using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Users.Requests.Commands;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Users.Handlers.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id);
        if (user == null)
            throw new NotFoundException(nameof(User), request.Id);
        
        await _userRepository.Delete(user);
        return Unit.Value;
    }
}