using Staris.Domain.Common;

namespace Staris.Domain.Entities;

public sealed class Planet : Entity
{
    public string Name { get; set; } = string.Empty;
    public int RotationPeriod { get; set; }
    public int OrbitalPeriod { get; set; }
    public int Diameter { get; set; }
    public string Climate { get; set; } = string.Empty;
    public string Gravity { get; set; } = string.Empty;
    public string Terrain { get; set; } = string.Empty;
    public decimal SurfaceWater { get; set; }
    public long Population { get; set; }


    //EF Relation
    public List<PlanetCharacter>? Residents { get; set; } = new ();

	public List<PlanetFilm>? Films { get; set; } = new();
}
