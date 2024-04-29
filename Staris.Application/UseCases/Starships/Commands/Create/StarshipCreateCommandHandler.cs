using AutoMapper;
using MediatR;
using Staris.Application.Data;
using Staris.Application.Shared.Dtos;
using Staris.Application.UseCases.Vehicles.Commands.Create;
using Staris.Domain.Entities;
using Staris.Domain.Enumerables;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Starships.Commands.Create;

internal class StarshipCreateCommandHandler : IRequestHandler<StarshipCreateCommand, StarshipDTO>
{
	private readonly IMapper _mapper;
	private readonly IVehicleRepository _vehicleRepository;
	private readonly IStarshipRepository _starshipRepository;
	private readonly IUnitOfWork _unitOfWork;

	public StarshipCreateCommandHandler(IMapper mapper,
		IVehicleRepository vehicleRepository,
		IStarshipRepository starshipRepository,
		IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_vehicleRepository = vehicleRepository;
		_starshipRepository = starshipRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<StarshipDTO> Handle(StarshipCreateCommand request, CancellationToken cancellationToken)
	{
		var vechicle = new Vehicle()
		{
			Type = TypeOfVehicle.Starship,
			Name = request.Name,
			Model = request.Model,
			Manufacturer = request.Manufacturer,
			Cost = request.Cost,
			Lenght = request.Lenght,
			MaxSpeed = request.MaxSpeed,
			Crew = request.Crew,
			Passengers = request.Passengers,
			CargoCapacity = request.CargoCapacity,
			Consumables = request.Consumables,
			Class = request.Class
	};

		var createdVechicle = _vehicleRepository.Create(vechicle);

		var starship = new Starship()
		{
			HyperdriveRating = request.HyperdriveRating,
			MaximumMegalights = request.MaximumMegalights,
			Vehicle = createdVechicle
			
		};

		_starshipRepository.Create(starship);
		await _unitOfWork.SaveChangesAsync(cancellationToken);


		var starshipDTO = _mapper.Map<StarshipDTO>(starship);

		return starshipDTO;
	}
}
