using Application.Shared.Dtos;
using Application.Shared.Dtos.Film;
using AutoMapper;
using Staris.Application.Shared.Dtos;
using Staris.Application.Shared.Dtos.Shared;
using Staris.Application.Shared.Requests;
using Staris.Application.UseCases.Characters.Commands.Create;
using Staris.Application.UseCases.Films.Commands.Create;
using Staris.Application.UseCases.Planets.Commands.Create;
using Staris.Application.UseCases.UserLogin.Commands.ByUserName;
using Staris.Domain.Entities;

namespace Staris.Application.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        //Maps for Login
        CreateMapsForLogin();
		CreateMapsForPlanets();
		CreateMapsForCharacters();
		CreateMapsForFilms();
		CreateMapsForVehicles();
        CreateMapsForStarships();
    }

    private void CreateMapsForLogin()
    {
		//Login Request to Command
		CreateMap<UserLoginRequest, LoginByUserNameCommand>();
	}
	
	private void CreateMapsForPlanets()
	{
		//Login Request to Command
		CreateMap<PlanetCreateRequest, PlanetCreateCommand>();

		//Domain to DTO
		CreateMap<Planet, PlanetDTO>()
			.ForMember(d => d.RotationPeriod, opt => opt.MapFrom(s => $"{s.RotationPeriod} hours"))
			.ForMember(d => d.OrbitalPeriod, opt => opt.MapFrom(s => $"{s.OrbitalPeriod} days"))
			.ForMember(d => d.Diameter, opt => opt.MapFrom(s => $"{s.Diameter} km"))
			.ForMember(d => d.Gravity, opt => opt.MapFrom(s => $"{s.Gravity} standard"))
			.ForMember(d => d.SurfaceWater, opt => opt.MapFrom(s => $"{s.SurfaceWater.ToString("N2")}%"))
			.ForMember(d => d.Population, opt => opt.MapFrom(s => s.Population.ToString()));

        CreateMap<Planet, PlanetCDTO>();
    }

    private void CreateMapsForCharacters()
    {
        //Login Request to Command
        CreateMap<CharacterCreateRequest, CharacterCreateCommand>();

        //Domain to DTO
        CreateMap<Character, CharacterDTO>()
			.ForMember(
				x => x.BirthYear,
				opt => opt.MapFrom(d => $"{d.BirthYear.ToString("N2")} {d.BirthYearPeriod}")
			)
			.ForMember(x => x.Gender, opt => opt.MapFrom(d => (d.Gender == 0) ? "Male" : "Female"));

		//Em casos em que o retorno possui menos informações
		//Normalmente crio uma DTO compacta para os relacionamentos.
        CreateMap<Character, CharacterCDTO>();
    }

	private void CreateMapsForFilms()
    {
        //Login Request to Command
        CreateMap<FilmCreateRequest, FilmCreateCommand>();

        //Domain to DTO
        CreateMap<Film, FilmDTO>()
            .ForMember(d => d.ReleaseDate, opt => opt.MapFrom(s => s.ReleaseDate.ToString("yyyy-MM-dd")));

		//Em casos em que o retorno possui menos informações
		//Normalmente crio uma DTO compacta para os relacionamentos.
		CreateMap<Film, FilmCDTO>();
	}

	private void CreateMapsForVehicles()
    {
        //Login Request to Command
        //todo: implementar
        //CreateMap<VehicleCreateRequest, VehicleCreateCommand>();

        //Domain to DTO
        CreateMap<Vehicle, VehicleDTO>()
			.ForMember(d => d.CostInCredits, opt => opt.MapFrom(s => s.Cost.ToString()))
			.ForMember(d => d.Length, opt => opt.MapFrom(s => $"{s.Lenght.ToString("N2")} meters"))
			.ForMember(d => d.MaxSpeed, opt => opt.MapFrom(s => $"{s.MaxSpeed.ToString("N2")} km/h"))
			.ForMember(d => d.Crew, opt => opt.MapFrom(s => s.Crew.ToString()))
			.ForMember(d => d.Passengers, opt => opt.MapFrom(s => s.Passengers.ToString()))
			.ForMember(d => d.CargoCapacity, opt => opt.MapFrom(s => $"{s.CargoCapacity.ToString("N2")} kg"))
			.ForMember(d => d.Consumables, opt => opt.MapFrom(s => $"{s.Consumables} years"));

		//Em casos em que o retorno possui menos informações
		//Normalmente crio uma DTO compacta para os relacionamentos.
		CreateMap<Vehicle, VehicleCDTO>();
	}

    private void CreateMapsForStarships()
    {
        //Login Request to Command
        //todo: implementar
        //CreateMap<StarshipCreateRequest, StarshipCreateCommand>();

        //Domain to DTO
        CreateMap<Starship, StarshipDTO>()
            .ForMember(d => d.CostInCredits, opt => opt.MapFrom(s => s.Vehicle!.Cost.ToString()))
            .ForMember(d => d.Length, opt => opt.MapFrom(s => $"{s.Vehicle!.Lenght.ToString("N2")} meters"))
            .ForMember(d => d.MaxSpeed, opt => opt.MapFrom(s => $"{s.Vehicle!.MaxSpeed.ToString("N2")} km/h"))
            .ForMember(d => d.Crew, opt => opt.MapFrom(s => s.Vehicle!.Crew.ToString()))
            .ForMember(d => d.Passengers, opt => opt.MapFrom(s => s.Vehicle!.Passengers.ToString()))
            .ForMember(d => d.CargoCapacity, opt => opt.MapFrom(s => $"{s.Vehicle!.CargoCapacity.ToString("N2")} kg"))
            .ForMember(d => d.Consumables, opt => opt.MapFrom(s => $"{s.Vehicle!.Consumables} years"))
            .ForMember(d => d.HyperdriveRating, opt => opt.MapFrom(s => s.HyperdriveRating.ToString()))
            .ForMember(d => d.Mglt, opt => opt.MapFrom(s => s.MaximumMegalights.ToString()));

        //Em casos em que o retorno possui menos informações
        //Normalmente crio uma DTO compacta para os relacionamentos.
        CreateMap<Starship, StarshipCDTO>();
    }
}
