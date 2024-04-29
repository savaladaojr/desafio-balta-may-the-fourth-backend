namespace Staris.Application.Shared.Requests;

public sealed record FilmCharacterLinkRequest(
	int FilmId,
	int CharacterId
);
