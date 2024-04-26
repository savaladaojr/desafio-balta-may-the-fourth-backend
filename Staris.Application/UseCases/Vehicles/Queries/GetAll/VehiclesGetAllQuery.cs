using MediatR;
using Staris.Application.Shared.Dtos;

namespace Staris.Application.UseCases.Vehicles.Queries.GetAll;

public class VehiclesGetAllQuery : IRequest<IEnumerable<VehicleDTO>>
{
}
