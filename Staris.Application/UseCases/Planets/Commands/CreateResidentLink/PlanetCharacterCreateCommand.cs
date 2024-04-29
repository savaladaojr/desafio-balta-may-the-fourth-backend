using Application.Shared.Dtos;
using MediatR;

namespace Staris.Application.UseCases.Planets.Commands.CreateResidentLink;

public sealed record PlanetCharacterCreateCommand(
	int CharacterId,
	int PlanetId
) : IRequest<PlanetDTO>;
