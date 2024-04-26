using Application.Shared.Dtos;
using MediatR;

namespace Staris.Application.Characters.Queries.GetById
{
	public class CharacterGetByIdQuery : IRequest<CharacterDto>
	{
        public int Id { get; set; }
    }


}
