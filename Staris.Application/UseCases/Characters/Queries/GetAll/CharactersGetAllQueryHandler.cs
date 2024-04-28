using AutoMapper;
using MediatR;
using Staris.Application.Shared.Dtos;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Characters.Queries.GetAll
{
    public class CharactersGetAllQueryHandler
        : IRequestHandler<CharactersGetAllQuery, IEnumerable<CharacterDTO>>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CharactersGetAllQueryHandler(
            ICharacterRepository characterRepository,
            IMapper mapper
        )
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CharacterDTO>> Handle(
            CharactersGetAllQuery request,
            CancellationToken cancellationToken
        )
        {
            var results = await _characterRepository.GetAllWithAllData();
            var finalResults = _mapper.Map<IEnumerable<CharacterDTO>>(results);

            return finalResults;
        }
    }
}
