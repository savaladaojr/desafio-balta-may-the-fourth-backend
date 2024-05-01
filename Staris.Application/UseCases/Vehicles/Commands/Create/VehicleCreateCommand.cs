using MediatR;
using Staris.Application.Shared.Dtos;

namespace Staris.Application.UseCases.Vehicles.Commands.Create;

public sealed record VehicleCreateCommand(
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
	string Class
) : IRequest<VehicleDTO>;


