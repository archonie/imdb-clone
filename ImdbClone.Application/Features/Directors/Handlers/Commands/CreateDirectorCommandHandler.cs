using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Director.Validators;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Directors.Requests.Commands;
using ImdbClone.Application.Responses;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Directors.Handlers.Commands;

public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, BaseCommandResponse>
{
    private readonly IDirectorRepository _directorRepository;
    private readonly IMapper _mapper;

    public CreateDirectorCommandHandler(IDirectorRepository directorRepository, IMapper mapper)
    {
        _directorRepository = directorRepository;
        _mapper = mapper;
    }
    public async Task<BaseCommandResponse> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateDirectorDtoValidator();
        var validationResult = await validator.ValidateAsync(request.DirectorDto);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        var director = _mapper.Map<Director>(request.DirectorDto);
        director = await _directorRepository.Add(director);
        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = director.Id;
        return response;
    }
}