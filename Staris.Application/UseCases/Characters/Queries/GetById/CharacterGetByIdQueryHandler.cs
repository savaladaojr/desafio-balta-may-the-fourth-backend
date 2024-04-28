using AutoMapper;
using MediatR;
using Staris.Application.Shared.Dtos;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Characters.Queries.GetById
{
    public class CharacterGetByIdQueryHandler
        : IRequestHandler<CharacterGetByIdQuery, CharacterDTO?>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CharacterGetByIdQueryHandler(
            ICharacterRepository characterRepository,
            IMapper mapper
        )
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<CharacterDTO?> Handle(
            CharacterGetByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await _characterRepository.GetByIdWithAllData(request.Id);

            if (result is null)
                return null;

            var finalResult = _mapper.Map<CharacterDTO>(result);

            return finalResult;
        }
    }
}
