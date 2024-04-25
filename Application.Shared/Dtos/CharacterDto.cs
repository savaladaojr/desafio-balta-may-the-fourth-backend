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
    public IEnumerable<Shared.PlanetDto> Planets { get; set; } =
        Enumerable.Empty<Shared.PlanetDto>();
    public IEnumerable<Shared.FilmDto> Movies { get; set; } = 
        Enumerable.Empty<Shared.FilmDto>();
}
