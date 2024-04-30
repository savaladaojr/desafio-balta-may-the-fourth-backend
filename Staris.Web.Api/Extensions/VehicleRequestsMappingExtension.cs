using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.Common.Exceptions;
using Staris.Application.Shared.Dtos;
using Staris.Application.Shared.Dtos.Shared;
using Staris.Application.Shared.Requests;
using Staris.Application.UseCases.Vehicles.Commands.Create;
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
			.WithTags("Vehicles")
			.WithOrder(3)
			.WithName("Vehicles")
			.WithSummary("Return a list of Vehicles")
			.Produces(TypedResults.Ok().StatusCode, typeof(IEnumerable<VehicleDTO>))
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
			.WithTags("Vehicles")
			.WithOrder(3)
			.WithName("VehicleById")
			.WithSummary("Return a vehicle according to ID")
			.Produces(TypedResults.Ok().StatusCode, typeof(VehicleDTO))
			.WithOpenApi();


		app.MapPost(
			"/vehicles",
			[Authorize]
		async (
				IMediator mediator,
				IMapper mapper,
				VehicleCreateRequest request
			) =>
			{
				try
				{
					var req = mapper.Map<VehicleCreateCommand>(request);
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
			.WithTags("Vehicles")
			.WithOrder(3)
			.WithName("VehicleCreate}")
			.WithSummary("Create a new Vehicle")
			.Produces(TypedResults.Ok().StatusCode, typeof(VehicleDTO))
			.WithOpenApi().ExcludeFromDescription();
	}
}
