using MediatR;
using Staris.Application.Shared.Dtos;

namespace Staris.Application.UseCases.Characters.Commands.Create;

public sealed record CharacterCreateCommand(
	string Name,
	decimal BirthYear,
	string BirthYearPeriod,
	short Gender,
	string Mass,
	string Height,
	string EyeColor,
	string SkinColor,
	string HairColor,
	int HomeWorldId
) : IRequest<CharacterDTO>;

