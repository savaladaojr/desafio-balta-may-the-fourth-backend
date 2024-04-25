namespace Application.Shared.Dtos.Film;

public class FilmDto : BaseDto
{
    public string Title { get; set; } = string.Empty;
    public int Episode { get; set; }
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public IEnumerable<Shared.CharacterDto> Characters { get; set; } =
        Enumerable.Empty<Shared.CharacterDto>();
    public IEnumerable<Shared.PlanetDto> Planets { get; set; } =
        Enumerable.Empty<Shared.PlanetDto>();
    public IEnumerable<Shared.VehicleDto> Vehicles { get; set; } =
        Enumerable.Empty<Shared.VehicleDto>();
    public IEnumerable<Shared.StarshipDto> Starships { get; set; } =
        Enumerable.Empty<Shared.StarshipDto>();
}
