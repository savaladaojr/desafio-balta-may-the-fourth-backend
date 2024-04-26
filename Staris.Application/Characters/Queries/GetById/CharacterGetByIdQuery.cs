using Application.Shared.Dtos;
using MediatR;

namespace Staris.Application.Characters.Queries.GetById
{
	public class CharacterGetByIdQuery : IRequest<CharacterDTO>
	{
        public int Id { get; set; }
    }


}
