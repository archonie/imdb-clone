using ImdbClone.Application.DTOs.Director;
using MediatR;

namespace ImdbClone.Application.Features.Directors.Requests.Commands;

public class UpdateDirectorCommand : IRequest<Unit>
{
    public UpdateDirectorDto DirectorDto { get; set; }
    
    public UpdateDirectorFilmsDto UpdateDirectorFilmsDto { get; set; }
}