using Application.Shared.Dtos;
using AutoMapper;
using MediatR;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.Characters.Queries.GetById
{
	public class CharacterGetByIdQueryHandler : IRequestHandler<CharacterGetByIdQuery, CharacterDTO>
	{
		private readonly ICharacterRepository _characterRepository;
		private readonly IMapper _mapper;

		public CharacterGetByIdQueryHandler(ICharacterRepository characterRepository, IMapper mapper)
		{
			_characterRepository = characterRepository;
			_mapper = mapper;
		}

		public async Task<CharacterDTO> Handle(CharacterGetByIdQuery request, CancellationToken cancellationToken)
		{
			var result = await _characterRepository.GetByIdAsync(new object[] { request.Id });

			if (result == null)
			{
				throw new Exception($"Registro não com id {request.Id} encontrado");
			}

			var finalResult = _mapper.Map<CharacterDTO>(result);

			return finalResult;
		}
	}

}
