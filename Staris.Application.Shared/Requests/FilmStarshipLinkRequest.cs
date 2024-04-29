namespace Staris.Application.Shared.Requests;

public sealed record FilmStarshipLinkRequest(
	int FilmId,
	int StarshipId
);