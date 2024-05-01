using Application.Shared.Dtos.Film;
using AutoMapper;
using MediatR;
using Staris.Domain.Entities;
using Staris.Application.Data;
using Staris.Domain.Interfaces.Repositories;
using Staris.Application.UseCases.Films.Commands.CreateVehicleLink;

namespace Staris.Application.UseCases.Films.Commands.CreateStarshipLink;

internal class StarshipFilmCreateCommandHandler : IRequestHandler<StarshipFilmCreateCommand, FilmDTO>
{
	private readonly IMapper _mapper;
	private readonly IStarshipFilmRepository _starshipFilmRepository;
	private readonly IFilmRepository _filmRepository;
	private readonly IUnitOfWork _unitOfWork;

	public StarshipFilmCreateCommandHandler(IMapper mapper,
		IStarshipFilmRepository starshipFilmRepository,
		IFilmRepository filmRepository,
		IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_starshipFilmRepository = starshipFilmRepository;
		_filmRepository = filmRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<FilmDTO> Handle(StarshipFilmCreateCommand request, CancellationToken cancellationToken)
	{
		var starshipFilm = new StarshipFilm()
		{
			StartshipId = request.StarshipId,
			FilmId = request.FilmId
		};

		var created = _starshipFilmRepository.Create(starshipFilm);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		var film = await _filmRepository.GetByIdWithDataAsync(starshipFilm.FilmId);
		var FilmDTO = _mapper.Map<FilmDTO>(film);

		return FilmDTO;
	}
}
