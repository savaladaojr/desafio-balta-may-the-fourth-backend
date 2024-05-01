using Staris.Domain.Common;
using Staris.Domain.Enumerables;

namespace Staris.Domain.Entities;

public sealed class Character : Entity
{
    public string Name { get; set; } = string.Empty;
    public string BirthYear { get; set; } = string.Empty;
    public string BirthYearPeriod { get; set; } = string.Empty;
    //todo: precisa criar um enum ou armazenar o valor string como na API original
    public string Gender { get; set; } = string.Empty;
    public string Mass { get; set; } = string.Empty;
    public string Height { get; set; } = string.Empty;
    public string EyeColor { get; set; } = string.Empty;
    public string SkinColor { get; set; } = string.Empty;
    public string HairColor { get; set; } = string.Empty;
    public int? HomeWorldId { get; set; }


    //EF Relation
    public Planet? HomeWorld { get; init; }

    public List<CharacterFilm>? Films { get; init; }

	public List<PlanetCharacter>? PlanetsOfResidence { get; init; }

}
