using Application.Shared.Dtos;
using Application.Shared.Dtos.Film;
using AutoMapper;
using Staris.Application.Shared.Dtos;
using Staris.Application.Shared.Dtos.Shared;
using Staris.Application.Shared.Requests;
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
	}

    private void CreateMapsForCharacters()
    {

		//todo: Criar todos os mapeamos do Dominio para o DTO
		CreateMap<Character, CharacterDTO>()
			.ForMember(
				x => x.BirthYear,
				opt => opt.MapFrom(d => $"{d.BirthYear.ToString("N2")} {d.BirthYearPeriod}")
			)
			.ForMember(x => x.Gender, opt => opt.MapFrom(d => (d.Gender == 0) ? "Male" : "Female"));

		//Em casos em que o retorno possui menos informações
		//Normalmente crio uma DTO compacta para os relacionamentos.
		CreateMap<Planet, PlanetCDTO>();
	}

	private void CreateMapsForFilms()
	{
		//todo: Criar todos os mapeamos do Dominio para o DTO
		CreateMap<Film, FilmDTO>();

		//Em casos em que o retorno possui menos informações
		//Normalmente crio uma DTO compacta para os relacionamentos.
		CreateMap<Film, FilmCDTO>();
	}

	private void CreateMapsForVehicles()
	{
		//todo: Criar todos os mapeamos do Dominio para o DTO
		CreateMap<Vehicle, VehicleDTO>();

		CreateMap<Starship, StarshipDTO>();

		//Em casos em que o retorno possui menos informações
		//Normalmente crio uma DTO compacta para os relacionamentos.
		CreateMap<Starship, StarshipCDTO>();
	}
}
