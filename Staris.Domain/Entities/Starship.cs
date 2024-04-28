using Staris.Domain.Common;

namespace Staris.Domain.Entities;

public sealed class Starship
{
    public int VehicleId { get; set; }
    public decimal HyperdriveRating { get; set; }
    public int MaximumMegalights { get; set; }

    //EF Relation
    public Vehicle? Vehicle { get; init; }

	public List<StarshipFilm>? Films { get; init; } //Filtrar somento os Types == Vehicle
}

