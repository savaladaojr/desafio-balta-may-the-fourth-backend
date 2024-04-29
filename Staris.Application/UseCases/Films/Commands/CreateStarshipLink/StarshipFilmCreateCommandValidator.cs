using FluentValidation;
using Staris.Application.UseCases.Films.Commands.CreateVehicleLink;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Films.Commands.CreateStarshipLink
{
	public sealed class StarshipFilmCreateCommandValidator : AbstractValidator<StarshipFilmCreateCommand>
	{
		private readonly IFilmRepository _filmRepository;
		private readonly IStarshipRepository _starshipRepository;

		public StarshipFilmCreateCommandValidator(IFilmRepository filmRepository,
			IStarshipRepository starshipRepository)
		{
			_filmRepository = filmRepository;
			_starshipRepository = starshipRepository;

			RuleFor(p => p.FilmId)
				.NotEqual(0).WithName("Provide the Film.")
				.Must(filmId => CheckFilmExists(filmId)).WithMessage("Inform an existent Film.");

			RuleFor(p => p.StarshipId)
				.NotEqual(0).WithName("Provide the Starship.")
				.Must(starshipId => CheckVehicleExists(starshipId)).WithMessage("Inform an existent Starship.");

		}

		private bool CheckFilmExists(int filmId)
		{
			var film = _filmRepository.GetByIdAsync(new object[] { filmId }).Result;

			if (film == null) return false;

			return true;
		}

		private bool CheckVehicleExists(int starshipId)
		{
			var starship = _starshipRepository.GetByIdAsync(new object[] { starshipId }).Result;

			if (starship == null) return false;

			return true;
		}

	}
}
