using Application.Shared.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.Common.Exceptions;
using Staris.Application.Shared.Requests;
using Staris.Application.UseCases.Planets.Commands.Create;
using Staris.Application.UseCases.Planets.Commands.CreateResidentLink;
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
			.WithTags("Planets")
			.WithOrder(1)
			.WithName("Planets")
			.WithSummary("Return a list of planets")
			.Produces(TypedResults.Ok().StatusCode, typeof(IEnumerable<PlanetDTO>))
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
			.WithTags("Planets")
			.WithOrder(1)
			.WithName("PlanetById}")
			.WithSummary("Return a planet according to ID")
			.Produces(TypedResults.Ok().StatusCode, typeof(PlanetDTO))
			.WithOpenApi();


		app.MapPost(
			"/planets",
			[Authorize]
		async (
				IMediator mediator,
				IMapper mapper,
				PlanetCreateRequest request
			) =>
			{
				try
				{
					var req = mapper.Map<PlanetCreateCommand>(request);
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
			.WithTags("Planets")
			.WithOrder(1)
			.WithName("PlanetCreate}")
			.WithSummary("Create a new planet")
			.Produces(TypedResults.Ok().StatusCode, typeof(PlanetDTO))
			.WithOpenApi().ExcludeFromDescription();

		app.MapPost(
			"/planets/resident",
			[AllowAnonymous]
		async (
				IMediator mediator,
				IMapper mapper,
				PlanetCharacterLinkRequest request
			) =>
			{
				try
				{
					var req = new PlanetCharacterCreateCommand(request.CharacterId, request.PlanetId);
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
			.WithTags("Planets")
			.WithOrder(1)
			.WithName("PlanetCharacterLinkCreate}")
			.WithSummary("Create a link between a Planet and Character, it will be a planet resident.")
			.Produces(TypedResults.Ok().StatusCode, typeof(PlanetDTO))
			.WithOpenApi().ExcludeFromDescription();
	}
}
