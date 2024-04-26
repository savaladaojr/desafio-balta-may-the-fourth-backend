using Application.Shared.Dtos;
using MediatR;

namespace Staris.Application.Characters.Queries.GetAll
{
	public class CharacterGetAllQuery : IRequest<IEnumerable<CharacterDto>>
	{
    }

}
