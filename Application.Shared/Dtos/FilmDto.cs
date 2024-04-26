using Staris.Application.Shared.Dtos;
using Staris.Application.Shared.Dtos.Shared;

namespace Application.Shared.Dtos.Film;

public class FilmDto : BaseDto
{
    public string Title { get; set; } = string.Empty;
    public int Episode { get; set; }
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public IEnumerable<Staris.Application.Shared.Dtos.Shared.CharacterDto> Characters { get; set; } =
        Enumerable.Empty<Staris.Application.Shared.Dtos.Shared.CharacterDto>();
    public IEnumerable<Staris.Application.Shared.Dtos.Shared.PlanetDto> Planets { get; set; } =
        Enumerable.Empty<Staris.Application.Shared.Dtos.Shared.PlanetDto>();
    public IEnumerable<VehicleDto> Vehicles { get; set; } =
        Enumerable.Empty<VehicleDto>();
    public IEnumerable<StarshipDto> Starships { get; set; } =
        Enumerable.Empty<StarshipDto>();
}
