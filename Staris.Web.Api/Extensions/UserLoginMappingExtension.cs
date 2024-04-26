using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application.Shared.Requests;
using Staris.Application.UseCases.UserLogin.Commands.ByUserName;

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
                IValidator<LoginByUserNameCommand> validator,
                UserLoginRequest request
            ) =>
            {
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
            }
        );
    }
}
