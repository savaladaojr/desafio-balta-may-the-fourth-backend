using Staris.Application.Shared.Dtos;
using Staris.Application.Shared.Dtos.Shared;

namespace Application.Shared.Dtos;

public class PlanetDTO : BaseDTO
{
    public string Name { get; set; } = string.Empty;
    public string RotationPeriod { get; set; } = string.Empty;
    public string OrbitalPeriod { get; set; } = string.Empty;
    public string Diameter { get; set; } = string.Empty;
    public string Climate { get; set; } = string.Empty;
    public string Gravity { get; set; } = string.Empty;
    public string Terrain { get; set; } = string.Empty;
    public string SurfaceWater { get; set; } = string.Empty;
    public string Population { get; set; } = string.Empty;
    public IEnumerable<CharacterCDTO> Characters { get; set; } = 
        Enumerable.Empty<CharacterCDTO>();
    public IEnumerable<FilmCDTO> Movies { get; set; } = 
        Enumerable.Empty<FilmCDTO>();    
}
