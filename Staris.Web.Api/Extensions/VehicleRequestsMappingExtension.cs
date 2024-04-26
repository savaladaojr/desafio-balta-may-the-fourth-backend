using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.UseCases.Vehicles.Queries.GetAll;
using Staris.Application.UseCases.Vehicles.Queries.GetById;

namespace Staris.Web.Api.Extensions;

public static class VehicleRequestsMappingExtension
{
    public static void AddVehicleRequestsMapping(this WebApplication app)
    {
        app.MapGet(
                "/vehicles",
                [AllowAnonymous]
                async (IMediator mediator) =>
                {
                    var result = await mediator.Send(new VehiclesGetAllQuery());
                    return Results.Ok(result);
                }
            )
            .WithName("Vehicles")
            .WithOpenApi();

        app.MapGet(
                "/vehicles/{id:int}",
                [AllowAnonymous]
                async (IMediator mediator, int id) =>
                {
                    var result = await mediator.Send(new VehicleGetByIdQuery { Id = id });
                    return result is not null ? Results.Ok(result) : Results.NotFound();
                }
            )
            .WithName("VehicleById")
            .WithOpenApi();
    }
}
