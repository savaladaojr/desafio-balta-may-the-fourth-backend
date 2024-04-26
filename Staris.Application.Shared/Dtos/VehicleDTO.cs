using Staris.Application.Shared.Dtos.Shared;

namespace Staris.Application.Shared.Dtos;

public class VehicleDTO : BaseDTO
{
	public string Name { get; set; } = string.Empty;
	public string Model { get; set; } = string.Empty;
	public string Manufacturer { get; set; } = string.Empty;
	public string CostInCredits { get; set; } = string.Empty;
	public string Length { get; set; } = string.Empty;
	public string MaxSpeed { get; set; } = string.Empty;
	public string Crew { get; set; } = string.Empty;
	public string Passengers { get; set; } = string.Empty;
	public string CargoCapacity { get; set; } = string.Empty;
	public string Class { get; set; } = string.Empty;
	public string Consumables { get; set; } = string.Empty;
	public IEnumerable<FilmCDTO> Movies { get; set; } =
		Enumerable.Empty<FilmCDTO>();
}
