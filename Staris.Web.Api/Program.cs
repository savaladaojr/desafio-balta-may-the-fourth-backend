using MediatR;
using Microsoft.AspNetCore.Authorization;
using Staris.Application;
using Staris.Application.Characters.Queries.GetAll;
using Staris.Application.Characters.Queries.GetById;
using Staris.Application.Configurations;
using Staris.Application.Shared.Requests;
using Staris.Application.UserLogin.Commands.ByUserName;
using Staris.Domain;
using Staris.Infra;
using Staris.Web.Api;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding Application Settings to the services.
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));

// Adding layers Dependency Injection
builder.Services.AddDomainDependencyInjection();
builder.Services.AddApplicationDependencyInjection();
builder.Services.AddInfraDependencyInjection(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerDependencyInjection();
builder.Services.AddAuthenticationJWTBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

///////////////////////////////////////
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//
app.UseAuthentication();
app.UseAuthorization();



app.MapPost("/security/login", [AllowAnonymous]
	async (IMediator mediator, UserLoginRequest request) =>
	{
		var result = await mediator.Send(new LoginByUserNameCommand() { UserName = request.UserName, Password = request.Password });
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

app.MapGet("/Characters/", [AllowAnonymous]
	async (IMediator mediator) =>
	{
		var result = await mediator.Send(new CharacterGetAllQuery());
		return Results.Ok(result);
	}
)
.WithName("Characters")
.WithOpenApi();


app.MapGet("/Characters/{id:int}", [AllowAnonymous]
async (IMediator mediator, int id) =>
{
	var result = await mediator.Send(new CharacterGetByIdQuery() { Id = id});
	return Results.Ok(result);
}
)
.WithName("CharactersById")
.WithOpenApi();


app.Run();
