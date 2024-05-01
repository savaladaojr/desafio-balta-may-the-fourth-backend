using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.Common.Exceptions;
using Staris.Application.Shared.Dtos;
using Staris.Application.Shared.Requests;
using Staris.Application.UseCases.Starships.Commands.Create;
using Staris.Application.UseCases.Starships.Queries.GetAll;
using Staris.Application.UseCases.Starships.Queries.GetById;
using Staris.Application.UseCases.Vehicles.Commands.Create;

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
			.WithTags("Starships")
			.WithOrder(4)
			.WithName("Starships")
			.WithSummary("Return a list of Starships")
			.Produces(TypedResults.Ok().StatusCode, typeof(IEnumerable<StarshipDTO>))
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
			.WithTags("Starships")
			.WithOrder(4)
			.WithName("StarshipById")
			.WithSummary("Return a starship according to ID")
			.Produces(TypedResults.Ok().StatusCode, typeof(StarshipDTO))
			.WithOpenApi();


		app.MapPost(
			"/starships",
			[Authorize]
		async (
				IMediator mediator,
				IMapper mapper,
				StarshipCreateRequest request
			) =>
			{
				try
				{
					var req = mapper.Map<StarshipCreateCommand>(request);
					var result = await mediator.Send(req);
					return Results.Ok(result);
				}
				catch (ValidationException validationException)
				{
					return Results.ValidationProblem(validationException.Errors.ToDictionary());
				}
				catch (Exception ex)
				{
					return Results.BadRequest();
				}
			}
		)
			.WithTags("Starships")
			.WithOrder(4)
			.WithName("CreateCharacterLink}")
			.WithSummary("Create a new Starship")
			.Produces(TypedResults.Ok().StatusCode, typeof(StarshipDTO))
			.WithOpenApi().ExcludeFromDescription();

	}
}
