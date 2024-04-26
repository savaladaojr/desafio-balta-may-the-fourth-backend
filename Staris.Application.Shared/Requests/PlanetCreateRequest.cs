namespace Staris.Application.Shared.Requests;

public sealed record PlanetCreateRequest(
	string Name,
	int RotationPeriod,
	int OrbitalPeriod,
	int Diameter,
	string Climate,
	decimal Gravity,
	string Terrain,
	decimal SurfaceWater,
	long Population
);
