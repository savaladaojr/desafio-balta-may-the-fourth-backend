using Application.Shared.Dtos.Film;
using MediatR;

namespace Staris.Application.UseCases.Films.Commands.CreatePlanetLink;

public sealed record PlanetFilmCreateCommand(
	int PlanetId,
	int FilmId
) : IRequest<FilmDTO>;
