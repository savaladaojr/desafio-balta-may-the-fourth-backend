using System.Security.Principal;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.UseCases.Planets.Queries.GetAll;
using Staris.Application.UseCases.Planets.Queries.GetById;

namespace Staris.Web.Api.Extensions;

public static class PlanetRequestsMappingExtension
{
    public static void AddPlanetRequestsMapping(this WebApplication app)
    {
        app.MapGet(
                "/planets",
                [AllowAnonymous]
                async (IMediator mediator) =>
                {
                    var result = await mediator.Send(new PlanetsGetAllQuery());
                    return Results.Ok(result);
                }
            )
            .WithName("Planets")
            .WithOpenApi();

        app.MapGet(
                "/planets/{id:int}",
                [AllowAnonymous]
                async (IMediator mediator, int id) =>
                {
                    var result = await mediator.Send(new PlanetGetByIdQuery { Id = id });
                    return result is not null ? Results.Ok(result) : Results.NotFound();
                }
            )
            .WithName("PlanetById")
            .WithOpenApi();
    }
}
