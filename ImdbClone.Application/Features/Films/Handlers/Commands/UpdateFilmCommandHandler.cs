using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Film.Validators;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Films.Requests.Commands;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Films.Handlers.Commands;

public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IActorRepository _actorRepository;
    private readonly IFilmRepository _filmRepository;
    private readonly IMapper _mapper;
    private readonly IDirectorRepository _directorRepository;

    public UpdateFilmCommandHandler(
        IUserRepository userRepository,
        IActorRepository actorRepository, IFilmRepository filmRepository, IMapper mapper,
        IDirectorRepository directorRepository)
    {
        _userRepository = userRepository;
        _actorRepository = actorRepository;
        _filmRepository = filmRepository;
        _mapper = mapper;
        _directorRepository = directorRepository;
    }

    public async Task<Unit> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
    {
        if (request.FilmDto != null)
        {
            var validator = new UpdateFilmDtoValidator(_directorRepository);
            var validationResult = await validator.ValidateAsync(request.FilmDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var film = await _filmRepository.Get(request.FilmDto.Id);
            _mapper.Map(request.FilmDto, film);
            await _filmRepository.Update(film);
        }
        else if (request.FilmDirectorDto != null)
        {
            
            var validator = new UpdateFilmDirectorDtoValidator(_directorRepository);
            var validationResult = await validator.ValidateAsync(request.FilmDirectorDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var film = await _filmRepository.Get(request.FilmDirectorDto.Id);
            var director = _mapper.Map<Director>(await _directorRepository.Get(request.FilmDirectorDto.DirectorId));
            await _filmRepository.ChangeDirector(film, director);
        }
        else if (request.UserListDto != null)
        {
            var film = await _filmRepository.Get(request.UserListDto.Id);
            var user = _mapper.Map<ApplicationUser>(await _userRepository.Get(request.UserListDto.UserId));
            await _filmRepository.AddUser(film, user);
        }
        // else if (request.UpdateFilmCharactersListDto != null)
        // {
        //     var validator = new UpdateFilmCharactersListDtoValidator(_filmRepository, _actorRepository);
        //     var validationResult = await validator.ValidateAsync(request.UpdateFilmCharactersListDto);
        //     if (!validationResult.IsValid)
        //     {
        //         throw new ValidationException(validationResult);
        //     }
        //
        //     var character = _mapper.Map<Character>(request.UpdateFilmCharactersListDto.CharacterDto);
        //     await _filmRepository.AddCharacter(film, character);
        // }

        return Unit.Value;
    }
}