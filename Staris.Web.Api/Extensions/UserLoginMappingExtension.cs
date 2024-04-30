//using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.Shared.Requests;
using Staris.Application.UseCases.UserLogin.Commands.ByUserName;
using Staris.Application.Common.Exceptions;
using AutoMapper;

namespace Staris.Web.Api.Extensions;

public static class UserLoginMappingExtension
{
    public static void AddUserLoginMapping(this WebApplication app)
    {
        app.MapPost(
            "/security/login",
            [AllowAnonymous]
            async (
                IMediator mediator,
                IMapper mapper,
                //IValidator<LoginByUserNameCommand> validator,
                UserLoginRequest request
            ) =>
            {
				/*
				var req = new LoginByUserNameCommand()
                {
                    UserName = request.UserName,
                    Password = request.Password
                };

                var validationResults = await validator.ValidateAsync(req);
                if (!validationResults.IsValid)
                    return Results.ValidationProblem(validationResults.ToDictionary());

                var result = await mediator.Send(req);
                if (result.Token == string.Empty)
                {
                    return Results.Unauthorized();
                }
                else
                {
                    return Results.Ok(result);
                }
                */

				try
				{
                    var req = mapper.Map<LoginByUserNameCommand>(request);
					var result = await mediator.Send(req);
					if (result.Token != string.Empty)
					{
						return Results.Ok(result);
					}

					return Results.Unauthorized();
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
            .WithTags("General")
            .WithOrder(100)
			.WithName("SecurityLoginByUserName}")
			.WithSummary("Authenticate an user.")
            .WithDescription("Uses Admin as username and 12345678 as password to obtain a JWT token. Use the Token to allow the Post, Put and Delete Methods.")
            .WithOpenApi().ExcludeFromDescription();

	}
}
