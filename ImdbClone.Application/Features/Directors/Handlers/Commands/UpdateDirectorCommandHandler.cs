using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Director.Validators;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Directors.Requests.Commands;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Directors.Handlers.Commands;

public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, Unit>
{
    private readonly IFilmRepository _filmRepository;
    private readonly IDirectorRepository _directorRepository;
    private readonly IMapper _mapper;

    public UpdateDirectorCommandHandler(IFilmRepository filmRepository, IDirectorRepository directorRepository,IMapper mapper)
    {
        _filmRepository = filmRepository;
        _directorRepository = directorRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
    {
        

        if (request.DirectorDto != null)
        {
            var validator = new UpdateDirectorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DirectorDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var director = await _directorRepository.Get(request.DirectorDto.Id);
            _mapper.Map(request.DirectorDto, director);
            await _directorRepository.Update(director);
        }
        // else if (request.UpdateDirectorFilmsDto != null)
        // {
        //     // var validator = new UpdateDirectorFilmsDtoValidator(_filmRepository,_directorRepository);
        //     // var validationResult = await validator.ValidateAsync(request.UpdateDirectorFilmsDto);
        //     // if (!validationResult.IsValid)
        //     // {
        //     //     throw new ValidationException(validationResult);
        //     // }
        //     var director = await _directorRepository.Get(request.UpdateDirectorFilmsDto.Id);
        //     var film = _mapper.Map<Film>(await _filmRepository.Get(request.UpdateDirectorFilmsDto.FilmId));
        //     await _directorRepository.AddFilm(director.Id, film.Id);
        // }

        return Unit.Value;
    }
}