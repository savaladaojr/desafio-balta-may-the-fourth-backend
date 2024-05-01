using FluentValidation;
using Staris.Application.UseCases.Planets.Commands.Create;
using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Application.UseCases.Films.Commands.Create;

public sealed class CharacterFilmCreateCommandValidator : AbstractValidator<CharacterFilmCreateCommand>
{
	private readonly IFilmRepository _filmRepository;
	private readonly ICharacterRepository _characterRepository;

	public CharacterFilmCreateCommandValidator(IFilmRepository filmRepository,
		ICharacterRepository characterRepository)
    {
		_filmRepository = filmRepository;
		_characterRepository = characterRepository;

		RuleFor(p => p.FilmId)
			.NotEqual(0).WithName("Provide the Film.")
			.Must(filmId => CheckFilmExists(filmId)).WithMessage("Inform an existent Film.");

		RuleFor(p => p.CharacterId)
			.NotEqual(0).WithName("Provide the Character.")
			.Must(characterId => CheckCharacterExists(characterId)).WithMessage("Inform an existent Character.");

	}

	private bool CheckFilmExists(int filmId)
	{
		var film = _filmRepository.GetByIdAsync(new object[] { filmId }).Result;

		if (film == null) return false;

		return true;
	}

	private bool CheckCharacterExists(int characterId)
	{
		var character = _characterRepository.GetByIdAsync(new object[] { characterId }).Result;

		if (character == null) return false;

		return true;
	}

}
