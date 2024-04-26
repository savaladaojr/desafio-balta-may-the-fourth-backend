using Staris.Application.Shared.Dtos;
using Staris.Application.Shared.Dtos.Shared;

namespace Application.Shared.Dtos;

public class CharacterDto : BaseDto
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
    
    //public IEnumerable<FilmDto> Movies { get; set; } = 
      //  Enumerable.Empty<FilmDto>();
}
