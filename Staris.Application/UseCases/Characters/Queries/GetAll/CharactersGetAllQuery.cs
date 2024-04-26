using MediatR;
using Staris.Application.Shared.Dtos;

namespace Staris.Application.UseCases.Characters.Queries.GetAll
{
    public class CharactersGetAllQuery : IRequest<IEnumerable<CharacterDTO>> { }
}
