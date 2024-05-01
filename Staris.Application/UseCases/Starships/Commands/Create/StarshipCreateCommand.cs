using MediatR;
using Staris.Application.Shared.Dtos;

namespace Staris.Application.UseCases.Starships.Commands.Create;

public sealed record StarshipCreateCommand(
	string Name,
	string Model,
	string Manufacturer,
	decimal Cost,
	decimal Lenght,
	decimal MaxSpeed,
	string Crew,
	int Passengers,
	decimal CargoCapacity,
	int Consumables,
	string ConsumablesPeriod,
	string Class,
	decimal HyperdriveRating,
	int MaximumMegalights
) : IRequest<StarshipDTO>;


