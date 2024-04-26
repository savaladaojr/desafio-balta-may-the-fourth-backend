using Application.Shared.Dtos;
using MediatR;

namespace Staris.Application.UseCases.Planets.Queries.GetAll;

public class PlanetsGetAllQuery : IRequest<IEnumerable<PlanetDTO>>
{    
}
