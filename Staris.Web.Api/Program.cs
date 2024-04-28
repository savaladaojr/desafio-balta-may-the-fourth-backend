using Staris.Application;
using Staris.Application.Configurations;
using Staris.Domain;
using Staris.Infra;
using Staris.Web.Api;
using Staris.Web.Api.Extensions;


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

// Mapeamentos dos Requests
app.AddUserLoginMapping();
app.AddCharacterRequestsMapping();
app.AddFilmRequestsMapping();
app.AddPlanetRequestsMapping();
app.AddStarshipRequestsMapping();
app.AddVehicleRequestsMapping();

app.Run();