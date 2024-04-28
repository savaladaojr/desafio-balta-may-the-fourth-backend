using AutoMapper;
using MediatR;
using Staris.Application.Data;
using Staris.Application.Shared.Dtos;
using Staris.Application.UseCases.Characters.Commands.Create;
using Staris.Domain.Entities;
using Staris.Domain.Enumerables;
using Staris.Domain.Interfaces.Repositories;
using System.Reflection;
using System.Security.Claims;

namespace Staris.Application.UseCases.Vehicles.Commands.Create;

internal class VehicleCreateCommandHandler : IRequestHandler<VehicleCreateCommand, VehicleDTO>
{
	private readonly IMapper _mapper;
	private readonly IVehicleRepository _vehicleRepository;
	private readonly IUnitOfWork _unitOfWork;

	public VehicleCreateCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
	{
		_mapper = mapper;
		_vehicleRepository = vehicleRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<VehicleDTO> Handle(VehicleCreateCommand request, CancellationToken cancellationToken)
	{
		var vechicle = new Vehicle()
		{
			Type = TypeOfVehicle.Vehicle,
			Name = request.Name,
			Model = request.Model,
			Manufacturer = request.Manufacturer,
			Cost  = request.Cost,
			Lenght =  request.Lenght,
			MaxSpeed = request.MaxSpeed,
			Crew = request.Crew,
			Passengers = request.Passengers,
			CargoCapacity = request.CargoCapacity,
			Consumables = request.Consumables,
			Class = request.Class
		};

		var createdVechicle = _vehicleRepository.Create(vechicle);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		var vehicleDTO = _mapper.Map<VehicleDTO>(createdVechicle);

		return vehicleDTO;
	}
}
