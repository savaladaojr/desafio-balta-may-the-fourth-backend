namespace Staris.Application.Shared.Requests;

public sealed record PlanetCharacterLinkRequest(
	int PlanetId,
	int CharacterId
);
