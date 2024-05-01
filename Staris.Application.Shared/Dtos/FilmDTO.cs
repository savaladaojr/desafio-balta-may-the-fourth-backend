using Staris.Application.Shared.Dtos;
using Staris.Application.Shared.Dtos.Shared;

namespace Application.Shared.Dtos.Film;

public class FilmDTO : BaseDTO
{
    public string Title { get; set; } = string.Empty;
    public int Episode { get; set; }
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public string ReleaseDate { get; set; } = string.Empty;
    public IEnumerable<CharacterCDTO> Characters { get; set; } =
        Enumerable.Empty<CharacterCDTO>();
    public IEnumerable<PlanetCDTO> Planets { get; set; } =
        Enumerable.Empty<PlanetCDTO>();
    public IEnumerable<VehicleCDTO> Vehicles { get; set; } =
        Enumerable.Empty<VehicleCDTO>();
    public IEnumerable<StarshipCDTO> Starships { get; set; } =
        Enumerable.Empty<StarshipCDTO>();
}
