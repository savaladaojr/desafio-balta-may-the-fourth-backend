using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.UseCases.Starships.Queries.GetAll;
using Staris.Application.UseCases.Starships.Queries.GetById;

namespace Staris.Web.Api.Extensions;

public static class StarshipRequestsMapping
{
    public static void AddStarshipRequestsMapping(this WebApplication app)
    {
        app.MapGet(
                "/starships",
                [AllowAnonymous]
                async (IMediator mediator) =>
                {
                    var result = await mediator.Send(new StarshipsGetAllQuery());
                    return Results.Ok(result);
                }
            )
            .WithName("Starships")
            .WithOpenApi();

        app.MapGet(
                "/starships/{id:int}",
                [AllowAnonymous]
                async (IMediator mediator, int id) =>
                {
                    var result = await mediator.Send(new StarshipGetByIdQuery { Id = id });
                    return result is not null ? Results.Ok(result) : Results.NotFound();
                }
            )
            .WithName("StarshipById")
            .WithOpenApi();
    }
}
