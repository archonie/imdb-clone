using ImdbClone.Application.DTOs.Director;
using MediatR;

namespace ImdbClone.Application.Features.Directors.Requests.Queries;

public class GetDirectorDetailRequest : IRequest<DirectorDto>
{
    public int Id { get; set; }
}