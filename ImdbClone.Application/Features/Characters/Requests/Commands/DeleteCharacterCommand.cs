using MediatR;

namespace ImdbClone.Application.Features.Characters.Requests.Commands;

public class DeleteCharacterCommand : IRequest<Unit>
{
    public int Id { get; set; }
}