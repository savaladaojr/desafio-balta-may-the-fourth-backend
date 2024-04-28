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
			.GreaterThan(0).WithMessage("Inform a number denoting the gravity of this planet, where \"1\" is normal or 1 standard G. \"2\" is twice or 2 standard Gs. \"0.5\" is half or 0.5 standard Gs.")
			.Must(number => !number.Equals(1) || !number.Equals(2) || !number.Equals(0.5))
				.WithMessage("the gravity must be \"1\" for normal or 1 standard G. \"2\" for twice or 2 standard Gs. \"0.5\" for half or 0.5 standard Gs.");

		RuleFor(p => p.Terrain)
			.NotEmpty().WithMessage("Enter the Planet Terrain. If the terrain of this planet varies, separate the different terrains with commas.");

		RuleFor(p => p.SurfaceWater)
			.Must(number => !(number < 0))
				.WithMessage("Provide the percentage of the planet’s surface covered by naturally occurring water or bodies of water.");

		RuleFor(p => p.Population)
			.GreaterThan(0).WithMessage("Inform the average population of sentient beings inhabiting this planet.");


	}

}


