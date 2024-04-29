using FluentValidation;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Films.Commands.CreatePlanetLink
{
	public sealed class PlanetFilmCreateCommandValidator : AbstractValidator<PlanetFilmCreateCommand>
	{
		private readonly IFilmRepository _filmRepository;
		private readonly IPlanetRepository _planetRepository;

		public PlanetFilmCreateCommandValidator(IFilmRepository filmRepository,
			IPlanetRepository planetRepository)
		{
			_filmRepository = filmRepository;
			_planetRepository = planetRepository;

			RuleFor(p => p.FilmId)
				.NotEqual(0).WithName("Provide the Film.")
				.Must(filmId => CheckFilmExists(filmId)).WithMessage("Inform an existent Film.");

			RuleFor(p => p.PlanetId)
				.NotEqual(0).WithName("Provide the Planet.")
				.Must(planetId => CheckPlanetExists(planetId)).WithMessage("Inform an existent Planet.");

		}

		private bool CheckFilmExists(int filmId)
		{
			var film = _filmRepository.GetByIdAsync(new object[] { filmId }).Result;

			if (film == null) return false;

			return true;
		}

		private bool CheckPlanetExists(int planetId)
		{
			var character = _planetRepository.GetByIdAsync(new object[] { planetId }).Result;

			if (character == null) return false;

			return true;
		}

	}
}
