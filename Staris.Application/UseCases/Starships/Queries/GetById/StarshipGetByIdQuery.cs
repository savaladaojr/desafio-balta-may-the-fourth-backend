using MediatR;
using Staris.Application.Shared.Dtos;

namespace Staris.Application.UseCases.Starships.Queries.GetById;

public class StarshipGetByIdQuery : BaseGetByIdQuery, IRequest<StarshipDTO>
{
    
}
