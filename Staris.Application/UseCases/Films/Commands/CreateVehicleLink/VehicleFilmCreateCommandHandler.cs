using Application.Shared.Dtos.Film;
using AutoMapper;
using MediatR;
using Staris.Domain.Entities;
using Staris.Application.Data;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Films.Commands.CreateVehicleLink;

internal class VehicleFilmCreateCommandHandler : IRequestHandler<VehicleFilmCreateCommand, FilmDTO>
{
	private readonly IMapper _mapper;
	private readonly IVehicleFilmRepository _vehicleFilmRepository;
	private readonly IFilmRepository _filmRepository;
	private readonly IUnitOfWork _unitOfWork;

	public VehicleFilmCreateCommandHandler(IMapper mapper,
		IVehicleFilmRepository vehicleFilmRepository,
		IFilmRepository filmRepository,
		IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_vehicleFilmRepository = vehicleFilmRepository;
		_filmRepository = filmRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<FilmDTO> Handle(VehicleFilmCreateCommand request, CancellationToken cancellationToken)
	{
		var vehicleFilm = new VehicleFilm()
		{
			VehicleId = request.VehicleId,
			FilmId = request.FilmId
		};

		var created = _vehicleFilmRepository.Create(vehicleFilm);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		var film = await _filmRepository.GetByIdWithDataAsync(vehicleFilm.FilmId);
		var FilmDTO = _mapper.Map<FilmDTO>(film);

		return FilmDTO;
	}
}
