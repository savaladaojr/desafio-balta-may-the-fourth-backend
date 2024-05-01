namespace Staris.Application.Shared.Requests;

public sealed record PlanetCreateRequest(
	string Name,
	int RotationPeriod,
	int OrbitalPeriod,
	int Diameter,
	string Climate,
	string Gravity,
	string Terrain,
	decimal SurfaceWater,
	long Population
);
