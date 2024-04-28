using AutoMapper;
using MediatR;
using Staris.Application.Shared.Dtos;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Vehicles.Queries.GetAll;

public class VehiclesGetAllQueryHandler
    : IRequestHandler<VehiclesGetAllQuery, IEnumerable<VehicleDTO>>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public VehiclesGetAllQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VehicleDTO>> Handle(
        VehiclesGetAllQuery request,
        CancellationToken cancellationToken
    )
    {
        var results = await _vehicleRepository.GetAllAsync();
        var finalResults = _mapper.Map<IEnumerable<VehicleDTO>>(results);
        return finalResults;
    }
}
