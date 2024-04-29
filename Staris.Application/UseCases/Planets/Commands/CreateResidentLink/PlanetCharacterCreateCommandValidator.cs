using FluentValidation;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Planets.Commands.CreateResidentLink;

public sealed class PlanetCharacterCreateCommandValidator : AbstractValidator<PlanetCharacterCreateCommand>
{
	private readonly IPlanetRepository _planetRepository;
	private readonly ICharacterRepository _characterRepository;

	public PlanetCharacterCreateCommandValidator(IPlanetRepository planetRepository,
		ICharacterRepository characterRepository)
	{
		_planetRepository = planetRepository;
		_characterRepository = characterRepository;

		RuleFor(p => p.PlanetId)
			.NotEqual(0).WithName("Provide the Planet.")
			.Must(planetId => CheckPlanetExists(planetId)).WithMessage("Inform an existent Planet.");

		RuleFor(p => p.CharacterId)
			.NotEqual(0).WithName("Provide the Character.")
			.Must(characterId => CheckCharacterExists(characterId)).WithMessage("Inform an existent Character.");

	}

	private bool CheckPlanetExists(int planetId)
	{
		var planet = _planetRepository.GetByIdAsync(new object[] { planetId }).Result;

		if (planet == null) return false;

		return true;
	}

	private bool CheckCharacterExists(int characterId)
	{
		var character = _characterRepository.GetByIdAsync(new object[] { characterId }).Result;

		if (character == null) return false;

		return true;
	}

}
