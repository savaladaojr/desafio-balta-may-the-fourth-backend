using Application.Shared.Dtos;
using AutoMapper;
using MediatR;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.Characters.Queries.GetAll
{
	public class CharacterGetAllQueryHandler : IRequestHandler<CharacterGetAllQuery, IEnumerable<CharacterDTO>>
	{
		private readonly ICharacterRepository _characterRepository;
		private readonly IMapper _mapper;

		public CharacterGetAllQueryHandler(ICharacterRepository characterRepository, IMapper mapper)
        {
			_characterRepository = characterRepository;
			_mapper = mapper;
		}

        public async Task<IEnumerable<CharacterDTO>> Handle(CharacterGetAllQuery request, CancellationToken cancellationToken)
		{
			var results = await _characterRepository.GetAllAsync();
			var finalResults = _mapper.Map<IEnumerable<CharacterDTO>>(results);

			return finalResults;
		}
	}

}
