using AutoMapper;
using ImdbClone.Application.Contracts.Persistence;
using ImdbClone.Application.DTOs.Actor.Validators;
using ImdbClone.Application.Exceptions;
using ImdbClone.Application.Features.Actors.Requests.Commands;
using ImdbClone.Application.Responses;
using ImdbClone.Domain;
using MediatR;

namespace ImdbClone.Application.Features.Actors.Handlers.Commands;

public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, BaseCommandResponse>
{
    private readonly IActorRepository _actorRepository;
    private readonly IMapper _mapper;

    public CreateActorCommandHandler(IActorRepository actorRepository, IMapper mapper)
    {
        _actorRepository = actorRepository;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateActorDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ActorDto);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        var actor = _mapper.Map<Actor>(request.ActorDto);
        actor = await _actorRepository.Add(actor);
        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = actor.Id;
        return response;
    }
}