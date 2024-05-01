using Application.Shared.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.Shared.Requests;
using Staris.Application.UseCases.Characters.Commands.Create;
using Staris.Application.UseCases.Characters.Queries.GetAll;
using Staris.Application.UseCases.Characters.Queries.GetById;
using Staris.Application.Common.Exceptions;
using Staris.Application.Shared.Dtos;

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
			.WithTags("Characters")
			.WithOrder(2)
			.WithName("Characters")
			.WithSummary("Return a list of characters")
			.Produces(TypedResults.Ok().StatusCode, typeof(IEnumerable<CharacterDTO>))
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
			.WithTags("Characters")
			.WithOrder(2)
			.WithName("CharactersById}")
			.WithSummary("Return a character according to ID")
			.Produces(TypedResults.Ok().StatusCode, typeof(CharacterDTO))
			.WithOpenApi();


		app.MapPost(
			"/characters",
			[Authorize]
		async (
				IMediator mediator,
				IMapper mapper,
				CharacterCreateRequest request
			) =>
			{
				try
				{
					var req = mapper.Map<CharacterCreateCommand>(request);
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
			.WithTags("Characters")
			.WithOrder(2)
			.WithName("CharacterCreate}")
			.WithSummary("Create a new Character")
			.Produces(TypedResults.Ok().StatusCode, typeof(CharacterDTO))
			.WithOpenApi()
			.ExcludeFromDescription();
	}
}
