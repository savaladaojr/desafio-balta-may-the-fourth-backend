using Application.Shared.Dtos;
using MediatR;

namespace Staris.Application.UseCases.Planets.Commands.Create;

public sealed record PlanetCreateCommand(
	string Name,
	int RotationPeriod,
	int OrbitalPeriod,
	int Diameter,
	string Climate,
	string Gravity,
	string Terrain,
	decimal SurfaceWater,
	long Population
) : IRequest<PlanetDTO>;


