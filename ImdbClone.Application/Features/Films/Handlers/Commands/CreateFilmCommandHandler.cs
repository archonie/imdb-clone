using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Film.Validators;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Films.Requests.Commands;
using ImdbClone.Application.Responses;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Films.Handlers.Commands;

public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, BaseCommandResponse>
{
    private readonly IDirectorRepository _directorRepository;
    private readonly IFilmRepository _filmRepository;
    private readonly IMapper _mapper;

    public CreateFilmCommandHandler(IDirectorRepository directorRepository,IFilmRepository filmRepository, IMapper mapper)
    {
        _directorRepository = directorRepository;
        _filmRepository = filmRepository;
        _mapper = mapper;
    }
    public async Task<BaseCommandResponse> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateFilmDtoValidator(_directorRepository);
        var validationResult = await validator.ValidateAsync(request.FilmDto);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        
        var film = _mapper.Map<Film>(request.FilmDto);
        film = await _filmRepository.Add(film);
        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = film.Id;
        return response;
    }
}