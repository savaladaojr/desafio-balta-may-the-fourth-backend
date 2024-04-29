using Application.Shared.Dtos.Film;
using AutoMapper;
using MediatR;
using Staris.Domain.Entities;
using Staris.Application.Data;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Films.Commands.CreatePlanetLink;

internal class PlanetFilmCreateCommandHandler : IRequestHandler<PlanetFilmCreateCommand, FilmDTO>
{
	private readonly IMapper _mapper;
	private readonly IPlanetFilmRepository _planetFilmRepository;
	private readonly IFilmRepository _filmRepository;
	private readonly IUnitOfWork _unitOfWork;

	public PlanetFilmCreateCommandHandler(IMapper mapper,
		IPlanetFilmRepository planetFilmRepository,
		IFilmRepository filmRepository,
		IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_planetFilmRepository = planetFilmRepository;
		_filmRepository = filmRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<FilmDTO> Handle(PlanetFilmCreateCommand request, CancellationToken cancellationToken)
	{
		var planetFilm = new PlanetFilm()
		{
			PlanetId = request.PlanetId,
			FilmId = request.FilmId
		};

		var created = _planetFilmRepository.Create(planetFilm);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		var film = await _filmRepository.GetByIdWithDataAsync(planetFilm.FilmId);
		var FilmDTO = _mapper.Map<FilmDTO>(film);

		return FilmDTO;
	}
}
