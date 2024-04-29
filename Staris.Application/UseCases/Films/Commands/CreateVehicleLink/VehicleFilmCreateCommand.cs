using Application.Shared.Dtos.Film;
using MediatR;

namespace Staris.Application.UseCases.Films.Commands.CreateVehicleLink;

public sealed record VehicleFilmCreateCommand(
	int VehicleId,
	int FilmId
) : IRequest<FilmDTO>;
