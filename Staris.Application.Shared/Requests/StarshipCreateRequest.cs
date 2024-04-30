namespace Staris.Application.Shared.Requests;

public sealed record StarshipCreateRequest
(
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
);
