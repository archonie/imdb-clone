using MediatR;

namespace ImdbClone.Application.Features.Films.Requests.Commands;

public class DeleteFilmCommand : IRequest<Unit>
{
    public int Id { get; set; }
}