using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.UseCases.Films.Queries.GetAll;
using Staris.Application.UseCases.Films.Queries.GetById;

namespace Staris.Web.Api.Extensions;

public static class FilmRequestsMappingExtension
{
    public static void AddFilmRequestsMapping(this WebApplication app)
    {
        app.MapGet(
                "/movies",
                [AllowAnonymous]
                async (IMediator mediator) =>
                {
                    var result = await mediator.Send(new FilmsGetAllQuery());
                    return Results.Ok(result);
                }
            )
            .WithName("Films")
            .WithOpenApi();

        app.MapGet(
                "/movies/{id:int}",
                [AllowAnonymous]
                async (IMediator mediator, int id) =>
                {
                    var result = await mediator.Send(new FilmGetByIdQuery { Id = id });
                    return result is not null ? Results.Ok(result) : Results.NotFound();
                }
            )
            .WithName("FilmById")
            .WithOpenApi();
    }
}
