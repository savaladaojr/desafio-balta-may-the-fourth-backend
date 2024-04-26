using MediatR;
using Staris.Application.Shared.Dtos;

namespace Staris.Application.UseCases.Characters.Queries.GetById
{
	public class CharacterGetByIdQuery : BaseGetByIdQuery, IRequest<CharacterDTO>
	{
  }
}
