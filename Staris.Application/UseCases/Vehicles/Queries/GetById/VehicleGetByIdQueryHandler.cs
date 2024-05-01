using AutoMapper;
using MediatR;
using Staris.Application.Shared.Dtos;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Vehicles.Queries.GetById;

public class VehicleGetByIdQueryHandler : IRequestHandler<VehicleGetByIdQuery, VehicleDTO?>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;

    public VehicleGetByIdQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<VehicleDTO?> Handle(
        VehicleGetByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var result = await _vehicleRepository.GetByIdAsync(request.Id);
        if (result is null)
          return null;

        var finalResult = _mapper.Map<VehicleDTO>(result);
        return finalResult;
    }
}
