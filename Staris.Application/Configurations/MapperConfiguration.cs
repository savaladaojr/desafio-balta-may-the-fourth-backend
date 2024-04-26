using AutoMapper;
using Staris.Application.Shared.Dtos;
using Staris.Application.Shared.Dtos.Shared;
using Staris.Application.Shared.Requests;
using Staris.Application.UseCases.UserLogin.Commands.ByUserName;
using Staris.Domain.Entities;

namespace Staris.Application.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        //Maps for Login
        CreateMapsForLogin();


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

    private void CreateMapsForLogin()
    {

		//Login Request to Command
		CreateMap<UserLoginRequest, LoginByUserNameCommand>();
	}
}
