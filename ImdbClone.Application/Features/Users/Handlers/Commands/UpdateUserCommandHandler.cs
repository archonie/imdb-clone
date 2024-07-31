using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.User.Validators;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Users.Requests.Commands;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Users.Handlers.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IDirectorRepository _directorRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IDirectorRepository directorRepository,IUserRepository userRepository, IMapper mapper)
    {
        _directorRepository = directorRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        
        var user = await _userRepository.Get(request.UserDto.Id);
        if (request.UserDto != null)
        {
            var validator = new UpdateUserDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UserDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            _mapper.Map(request.UserDto, user);
            await _userRepository.Update(user);
        }
        else if (request.UpdateWatchedFilmsDto != null)
        {
            var validator = new UpdateWatchedFilmsDtoValidator(_directorRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateWatchedFilmsDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            
            var film = _mapper.Map<Film>(request.UpdateWatchedFilmsDto.WatchedFilm);
            await _userRepository.AddWatchedFilm(user, film);
        }

        return Unit.Value;
    }
}