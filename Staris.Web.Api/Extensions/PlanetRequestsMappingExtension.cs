using Application.Shared.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.Common.Exceptions;
using Staris.Application.Shared.Requests;
using Staris.Application.UseCases.Planets.Commands.Create;
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
			//.WithTags("Planet")
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
			//.WithTags("Planet")
			.WithName("PlanetById}")
			.WithSummary("Return a planet according to ID")
			.Produces(TypedResults.Ok().StatusCode, typeof(PlanetDTO))
			.WithOpenApi();


		app.MapPost(
			"/planets/create",
			[AllowAnonymous]
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
			.WithName("PlanetCreate}")
			.WithSummary("Create a new planet")
			.Produces(TypedResults.Ok().StatusCode, typeof(PlanetDTO))
			.WithOpenApi();
	}
}
