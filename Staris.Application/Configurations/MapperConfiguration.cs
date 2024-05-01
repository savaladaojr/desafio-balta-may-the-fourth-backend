using Application.Shared.Dtos;
using Application.Shared.Dtos.Film;
using AutoMapper;
using AutoMapper.Execution;
using Staris.Application.Shared.Dtos;
using Staris.Application.Shared.Dtos.Shared;
using Staris.Application.Shared.Requests;
using Staris.Application.UseCases.Characters.Commands.Create;
using Staris.Application.UseCases.Films.Commands.Create;
using Staris.Application.UseCases.Planets.Commands.Create;
using Staris.Application.UseCases.Starships.Commands.Create;
using Staris.Application.UseCases.UserLogin.Commands.ByUserName;
using Staris.Application.UseCases.Vehicles.Commands.Create;
using Staris.Domain.Entities;
using Staris.Domain.Enumerables;
using System;

namespace Staris.Application.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        //Maps for Login
        CreateMapsForLogin();
		CreateMapsForPlanets();
		CreateMapsForCharacters();
		CreateMapsForVehicles();
		CreateMapsForStarships();
		CreateMapsForFilms();	
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
			.ForMember(d => d.Population, opt => opt.MapFrom(s => s.Population.ToString()))
			.ForMember(d => d.Characters, opt => opt.MapFrom(s => s.Residents.Select(s => s.Character).ToList()))
			.ForMember(d => d.Movies, opt => opt.MapFrom(s => s.Films!.Select(s => s.Film).ToList()));


		CreateMap<Planet, PlanetCDTO>();
    }

    private void CreateMapsForCharacters()
	{
		CreateMap<TypeOfGender, string>().ConvertUsing(src => src.ToString().ToLower());

		//Login Request to Command
		CreateMap<CharacterCreateRequest, CharacterCreateCommand>();

		//Domain to DTO
		CreateMap<Character, CharacterDTO>()
			.ForMember(
				x => x.BirthYear,
				opt => opt.MapFrom(d => d.BirthYear)
			)
			.ForMember(x => x.Weight, opt => opt.MapFrom(d => d.Mass))
			.ForMember(x => x.Planet, opt => opt.MapFrom(d => d.HomeWorld))
			.ForMember(d => d.Movies, opt => opt.MapFrom(s => s.Films!.Select(s => s.Film).ToList()));

		//Em casos em que o retorno possui menos informações
		//Normalmente crio uma DTO compacta para os relacionamentos.
		CreateMap<Character, CharacterCDTO>();
    }

	private void CreateMapsForVehicles()
    {
        //Login Request to Command
        //todo: implementar
        CreateMap<VehicleCreateRequest, VehicleCreateCommand>();

        //Domain to DTO
        CreateMap<Vehicle, VehicleDTO>()
			.ForMember(d => d.CostInCredits, opt => opt.MapFrom(s => s.Cost.ToString()))
			.ForMember(d => d.Length, opt => opt.MapFrom(s => $"{s.Lenght.ToString("N2")} meters"))
			.ForMember(d => d.MaxSpeed, opt => opt.MapFrom(s => $"{s.MaxSpeed.ToString("N2")} km/h"))
			.ForMember(d => d.Crew, opt => opt.MapFrom(s => s.Crew.ToString()))
			.ForMember(d => d.Passengers, opt => opt.MapFrom(s => s.Passengers.ToString()))
			.ForMember(d => d.CargoCapacity, opt => opt.MapFrom(s => $"{s.CargoCapacity.ToString("N2")} kg"))
			.ForMember(d => d.Consumables, opt => opt.MapFrom(s => $"{s.Consumables} {s.ConsumablesPeriod}"))
			.ForMember(d => d.Movies, opt => opt.MapFrom(s => s.Films!.Select(s => s.Film).ToList()));

		//Em casos em que o retorno possui menos informações
		//Normalmente crio uma DTO compacta para os relacionamentos.
		CreateMap<Vehicle, VehicleCDTO>();
	}

    private void CreateMapsForStarships()
    {
        //Login Request to Command
        //todo: implementar
        CreateMap<StarshipCreateRequest, StarshipCreateCommand>();

        //Domain to DTO
        CreateMap<Starship, StarshipDTO>()
			.ForMember(d => d.Id, opt => opt.MapFrom(s => s.VehicleId))
			.ForMember(d => d.Name , opt => opt.MapFrom(s => s.Vehicle!.Name.ToString()))
			.ForMember(d => d.Model, opt => opt.MapFrom(s => s.Vehicle!.Model.ToString()))
			.ForMember(d => d.Manufacturer, opt => opt.MapFrom(s => s.Vehicle!.Manufacturer.ToString()))
			.ForMember(d => d.CostInCredits, opt => opt.MapFrom(s => s.Vehicle!.Cost.ToString()))
            .ForMember(d => d.Length, opt => opt.MapFrom(s => $"{s.Vehicle!.Lenght.ToString("N2")} meters"))
            .ForMember(d => d.MaxSpeed, opt => opt.MapFrom(s => $"{s.Vehicle!.MaxSpeed.ToString("N2")} km/h"))
            .ForMember(d => d.Crew, opt => opt.MapFrom(s => s.Vehicle!.Crew.ToString()))
            .ForMember(d => d.Passengers, opt => opt.MapFrom(s => s.Vehicle!.Passengers.ToString()))
            .ForMember(d => d.CargoCapacity, opt => opt.MapFrom(s => $"{s.Vehicle!.CargoCapacity.ToString("N2")} kg"))
            .ForMember(d => d.Consumables, opt => opt.MapFrom(s => $"{s.Vehicle!.Consumables} {s.Vehicle.ConsumablesPeriod}"))
			.ForMember(d => d.Class, opt => opt.MapFrom(s => s.Vehicle!.Class))
			.ForMember(d => d.HyperdriveRating, opt => opt.MapFrom(s => s.HyperdriveRating.ToString()))
            .ForMember(d => d.Mglt, opt => opt.MapFrom(s => s.MaximumMegalights.ToString()))
			.ForMember(d => d.Movies, opt => opt.MapFrom(s => s.Films!.Select(s => s.Film).ToList()));


		//Em casos em que o retorno possui menos informações
		//Normalmente crio uma DTO compacta para os relacionamentos.
		CreateMap<Starship, StarshipCDTO>()
			.ForMember(d => d.Id, opt => opt.MapFrom(s => s.VehicleId))
			.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Vehicle!.Name.ToString()));


	}

	private void CreateMapsForFilms()
	{
		//Login Request to Command
		CreateMap<FilmCreateRequest, FilmCreateCommand>();

		//Domain to DTO
		CreateMap<Film, FilmDTO>()
			.ForMember(d => d.ReleaseDate, opt => opt.MapFrom(s => s.ReleaseDate.ToString("yyyy-MM-dd")))
			.ForMember(d => d.Characters, opt => opt.MapFrom(s => s.Characters.Select(s => s.Character).ToList()))
			.ForMember(d => d.Planets, opt => opt.MapFrom(s => s.Planets.Select(s => s.Planet).ToList()))
			.ForMember(d => d.Vehicles, opt => opt.MapFrom(s => s.Vehicles.Select(s => s.Vehicle).ToList()))
			.ForMember(d => d.Starships, opt => opt.MapFrom(s => s.Starships.Select(s => s.Startship).ToList()));

		//Em casos em que o retorno possui menos informações
		//Normalmente crio uma DTO compacta para os relacionamentos.
		CreateMap<Film, FilmCDTO>();
	}

}