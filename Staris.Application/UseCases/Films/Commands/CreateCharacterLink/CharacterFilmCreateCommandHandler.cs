using Application.Shared.Dtos.Film;
using AutoMapper;
using MediatR;
using Staris.Domain.Entities;
using Staris.Application.Data;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Films.Commands.Create;

internal class CharacterFilmCreateCommandHandler : IRequestHandler<CharacterFilmCreateCommand, FilmDTO>
{
    private readonly IMapper _mapper;
    private readonly ICharacterFilmRepository _characterFilmRepository;
	private readonly IFilmRepository _filmRepository;
	private readonly IUnitOfWork _unitOfWork;

    public CharacterFilmCreateCommandHandler(IMapper mapper,
        ICharacterFilmRepository characterFilmRepository,
        IFilmRepository filmRepository,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
		_characterFilmRepository = characterFilmRepository;
		_filmRepository = filmRepository;
		_unitOfWork = unitOfWork;
    }

    public async Task<FilmDTO> Handle(CharacterFilmCreateCommand request, CancellationToken cancellationToken)
    {
        var characterFilm = new CharacterFilm()
        {
            CharacterId = request.CharacterId,
            FilmId = request.FilmId
        };

        var created = _characterFilmRepository.Create(characterFilm);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var film = await _filmRepository.GetByIdWithDataAsync(characterFilm.FilmId);
		var FilmDTO = _mapper.Map<FilmDTO>(film);

        return FilmDTO;
    }
}
