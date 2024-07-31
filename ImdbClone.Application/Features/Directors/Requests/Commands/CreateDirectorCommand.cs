using ImdbClone.Application.DTOs.Director;
using ImdbClone.Application.Responses;
using MediatR;

namespace ImdbClone.Application.Features.Directors.Requests.Commands;

public class CreateDirectorCommand : IRequest<BaseCommandResponse>
{
    public CreateDirectorDto DirectorDto { get; set; }
}