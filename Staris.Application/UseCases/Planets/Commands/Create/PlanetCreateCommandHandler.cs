using Application.Shared.Dtos;
using AutoMapper;
using MediatR;
using Staris.Application.Data;
using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Planets.Commands.Create;

public sealed class PlanetCreateCommandHandler : IRequestHandler<PlanetCreateCommand, PlanetDTO>
{
	private readonly IMapper _mapper;
	private readonly IPlanetRepository _planetRepository;
	private readonly IUnitOfWork _unitOfWork;

	public PlanetCreateCommandHandler(IMapper mapper, IPlanetRepository planetRepository, IUnitOfWork unitOfWork)
    {
		_mapper = mapper;
		_planetRepository = planetRepository;
		_unitOfWork = unitOfWork;
	}

    public async Task<PlanetDTO> Handle(PlanetCreateCommand request, CancellationToken cancellationToken)
	{
		var planet = new Planet() { 
			Name = request.Name,
			Population = request.Population,
			Climate = request.Climate,
			Diameter = request.Diameter,
			Gravity = request.Gravity,
			OrbitalPeriod = request.OrbitalPeriod,
			RotationPeriod = request.RotationPeriod,
			SurfaceWater = request.SurfaceWater,
			Terrain = request.Terrain
		};

		var createPlanet = _planetRepository.Create(planet);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		var planetDTO = _mapper.Map<PlanetDTO>(createPlanet);

		return planetDTO;	
	}
}

