using Application.Shared.Dtos.Film;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.Common.Exceptions;
using Staris.Application.Shared.Dtos;
using Staris.Application.Shared.Requests;
using Staris.Application.UseCases.Films.Commands.Create;
using Staris.Application.UseCases.Films.Commands.CreatePlanetLink;
using Staris.Application.UseCases.Films.Commands.CreateStarshipLink;
using Staris.Application.UseCases.Films.Commands.CreateVehicleLink;
using Staris.Application.UseCases.Films.Queries.GetAll;
using Staris.Application.UseCases.Films.Queries.GetById;
using Staris.Application.UseCases.Planets.Commands.CreateResidentLink;

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
			.WithTags("Movies")
			.WithOrder(5)
			.WithName("Films")
			.WithSummary("Return a list of start wars movies.")
			.Produces(TypedResults.Ok().StatusCode, typeof(IEnumerable<FilmDTO>))
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
			.WithTags("Movies")
			.WithOrder(5)
			.WithName("FilmById")
			.WithSummary("Return a movie according to ID.")
			.Produces(TypedResults.Ok().StatusCode, typeof(FilmDTO))
			.WithOpenApi();


		app.MapPost(
			"/movies",
			[Authorize]
		async (
				IMediator mediator,
				IMapper mapper,
				FilmCreateRequest request
			) =>
			{
				try
				{
					var req = mapper.Map<FilmCreateCommand>(request);
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
			.WithTags("Movies")
			.WithOrder(5)
			.WithName("FilmCreate}")
			.WithSummary("Create a new Movie")
			.Produces(TypedResults.Ok().StatusCode, typeof(FilmDTO))
			.WithOpenApi().ExcludeFromDescription();


		app.MapPost(
		"/movies/characters",
				[Authorize]
		async (
				IMediator mediator,
				IMapper mapper,
				FilmCharacterLinkRequest request
			) =>
			{
				try
				{
					var req = new CharacterFilmCreateCommand(request.CharacterId, request.FilmId);
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
			.WithTags("Movies")
			.WithOrder(5)
			.WithName("CharacterFilmCreateCommand}")
			.WithSummary("Create a link between a Film and Character, it will be a character of a film.")
			.Produces(TypedResults.Ok().StatusCode, typeof(FilmDTO))
			.WithOpenApi().ExcludeFromDescription();


		app.MapPost(
		"/movies/planets",
				[Authorize]
		async (
				IMediator mediator,
				IMapper mapper,
				FilmPlanetLinkRequest request
			) =>
				{
					try
					{
						var req = new PlanetFilmCreateCommand(request.PlanetId, request.FilmId);
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
			.WithTags("Movies")
			.WithOrder(5)
			.WithName("PlanetFilmCreateCommand}")
			.WithSummary("Create a link between a Film and Planet, it will be a planet of a film.")
			.Produces(TypedResults.Ok().StatusCode, typeof(FilmDTO))
			.WithOpenApi().ExcludeFromDescription();

		app.MapPost(
		"/movies/vehicles",
				[AllowAnonymous]
				async (
				IMediator mediator,
				IMapper mapper,
				FilmVehicleLinkRequest request
			) =>
				{
					try
					{
						var req = new VehicleFilmCreateCommand(request.VehicleId, request.FilmId);
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
			.WithTags("Movies")
			.WithOrder(5)
			.WithName("VehicleFilmCreateCommand}")
			.WithSummary("Create a link between a Film and Vehicle, it will be a vehicle of a film.")
			.Produces(TypedResults.Ok().StatusCode, typeof(FilmDTO))
			.WithOpenApi().ExcludeFromDescription();


		app.MapPost(
		"/movies/starships",
				[AllowAnonymous]
		async (
				IMediator mediator,
				IMapper mapper,
				FilmStarshipLinkRequest request
			) =>
				{
					try
					{
						var req = new StarshipFilmCreateCommand(request.StarshipId, request.FilmId);
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
			.WithTags("Movies")
			.WithOrder(5)
			.WithName("StarshipFilmCreateCommand}")
			.WithSummary("Create a link between a Film and Starship, it will be a startship of a film.")
			.Produces(TypedResults.Ok().StatusCode, typeof(FilmDTO))
			.WithOpenApi().ExcludeFromDescription();

	}
}
