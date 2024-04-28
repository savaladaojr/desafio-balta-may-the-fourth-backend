using Application.Shared.Dtos;
using MediatR;

namespace Staris.Application.UseCases.Planets.Queries.GetById;

public class PlanetGetByIdQuery : BaseGetByIdQuery, IRequest<PlanetDTO>
{
    
}
