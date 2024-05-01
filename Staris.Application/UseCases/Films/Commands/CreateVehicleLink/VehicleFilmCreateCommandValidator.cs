using FluentValidation;
using Staris.Domain.Enumerables;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Films.Commands.CreateVehicleLink
{
	public sealed class VehicleFilmCreateCommandValidator : AbstractValidator<VehicleFilmCreateCommand>
	{
		private readonly IFilmRepository _filmRepository;
		private readonly IVehicleRepository _vehicleRepository;

		public VehicleFilmCreateCommandValidator(IFilmRepository filmRepository,
			IVehicleRepository vehicleRepository)
		{
			_filmRepository = filmRepository;
			_vehicleRepository = vehicleRepository;

			RuleFor(p => p.FilmId)
				.NotEqual(0).WithName("Provide the Film.")
				.Must(filmId => CheckFilmExists(filmId)).WithMessage("Inform an existent Film.");

			RuleFor(p => p.VehicleId)
				.NotEqual(0).WithName("Provide the Vehicle.")
				.Must(vehicleId => CheckVehicleExists(vehicleId)).WithMessage("Inform an existent Vehicle.");

		}

		private bool CheckFilmExists(int filmId)
		{
			var film = _filmRepository.GetByIdAsync(new object[] { filmId }).Result;

			if (film == null) return false;

			return true;
		}

		private bool CheckVehicleExists(int vehicleId)
		{
			var character = _vehicleRepository.GetByIdAsync(new object[] { vehicleId }).Result;

			if (character == null) return false;
			if (character.Type != TypeOfVehicle.Vehicle) return false;

			return true;
		}

	}
}
