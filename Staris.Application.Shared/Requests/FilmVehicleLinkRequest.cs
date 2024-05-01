namespace Staris.Application.Shared.Requests;

public sealed record FilmVehicleLinkRequest(
	int FilmId,
	int VehicleId
);
