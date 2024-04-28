using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.UseCases.Characters.Queries.GetAll;
using Staris.Application.UseCases.Characters.Queries.GetById;

namespace Staris.Web.Api.Extensions;

public static class CharacterRequestsMapping
{
    public static void AddCharacterRequestsMapping(this WebApplication app)
    {
        app.MapGet(
                "/characters/",
                [AllowAnonymous]
                async (IMediator mediator) =>
                {
                    var result = await mediator.Send(new CharactersGetAllQuery());
                    return Results.Ok(result);
                }
            )
            .WithName("Characters")
            .WithOpenApi();

        app.MapGet(
                "/characters/{id:int}",
                [AllowAnonymous]
                async (IMediator mediator, int id) =>
                {
                    var result = await mediator.Send(new CharacterGetByIdQuery() { Id = id });
                    return result is not null ? Results.Ok(result) : Results.NotFound();
                }
            )
            .WithName("CharactersById")
            .WithOpenApi();
    }
}
