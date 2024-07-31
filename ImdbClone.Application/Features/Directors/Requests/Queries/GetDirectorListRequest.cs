using ImdbClone.Application.DTOs.Director;
using MediatR;

namespace ImdbClone.Application.Features.Directors.Requests.Queries;

public class GetDirectorListRequest : IRequest<List<DirectorListDto>>
{
    
}