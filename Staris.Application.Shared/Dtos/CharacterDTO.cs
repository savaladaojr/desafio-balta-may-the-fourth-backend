using Staris.Application.Shared.Dtos.Shared;

namespace Staris.Application.Shared.Dtos;

public class CharacterDTO : BaseDTO
{
    public string Name { get; set; } = string.Empty;
    public string Height { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
    public string HairColor { get; set; } = string.Empty;
    public string SkinColor { get; set; } = string.Empty;
    public string EyeColor { get; set; } = string.Empty;
    public string BirthYear { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;

    public PlanetCDTO? Planet { get; set; }
    
    public IEnumerable<FilmCDTO> Movies { get; set; } = 
        Enumerable.Empty<FilmCDTO>();
}
