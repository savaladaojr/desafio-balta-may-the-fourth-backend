using FluentValidation;

namespace Staris.Application.UseCases.Planets.Commands.Create;

public sealed class PlanetCreateCommandValidator : AbstractValidator<PlanetCreateCommand>
{
	public PlanetCreateCommandValidator()
	{
		RuleFor(p => p.Name)
			.NotEmpty().WithMessage("The Planet Name must be entered.")
			.Length(2, 100).WithMessage("The Planet Name must be between {MinLength} and {MaxLength} characters long.");

		RuleFor(p => p.RotationPeriod)
			.GreaterThan(0).WithMessage("Provide the number of standard hours this planet takes to complete a single rotation on its axis.");

		RuleFor(p => p.OrbitalPeriod)
			.GreaterThan(0).WithMessage("Provide the number of standard days this planet takes to complete a single orbit of its local star.");

		RuleFor(p => p.Diameter)
			.GreaterThan(0).WithMessage("Inform the diameter of this planet in kilometers.");

		RuleFor(p => p.Climate)
			.NotEmpty().WithMessage("Enter the Planet Climate. If the climate of this planet varies, separate the different climates with commas.");

		RuleFor(p => p.Gravity)
			.NotEmpty().WithMessage("Enter the Planet Gravity. If the gravity of this planet varies, separate the different gravities with commas.");

		RuleFor(p => p.Terrain)
			.NotEmpty().WithMessage("Enter the Planet Terrain. If the terrain of this planet varies, separate the different terrains with commas.");

		RuleFor(p => p.SurfaceWater)
			.Must(number => !(number < 0))
				.WithMessage("Provide the percentage of the planet’s surface covered by naturally occurring water or bodies of water.");

		RuleFor(p => p.Population)
			.GreaterThan(0).WithMessage("Inform the average population of sentient beings inhabiting this planet.");


	}

}


