namespace Staris.Application.Shared.Requests;

public sealed record FilmPlanetLinkRequest(
	int FilmId,
	int PlanetId
);
