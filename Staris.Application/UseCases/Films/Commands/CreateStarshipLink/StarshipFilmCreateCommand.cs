using Application.Shared.Dtos.Film;
using MediatR;

namespace Staris.Application.UseCases.Films.Commands.CreateStarshipLink;

public sealed record StarshipFilmCreateCommand(
	int StarshipId,
	int FilmId
) : IRequest<FilmDTO>;
