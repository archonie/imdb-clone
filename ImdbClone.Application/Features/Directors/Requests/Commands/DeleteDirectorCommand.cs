using MediatR;

namespace ImdbClone.Application.Features.Directors.Requests.Commands;

public class DeleteDirectorCommand : IRequest<Unit>
{
    public int Id { get; set; }
}