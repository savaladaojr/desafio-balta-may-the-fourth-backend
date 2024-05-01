using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Staris.Application.Configurations;
using System.Text;

namespace Staris.Web.Api
{
	public static class ApiDependecyInjection
	{

		/// <summary>
		/// Responsável por adicionar as dependências a serem resolvidas no projeto de Web API
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddSwaggerDependencyInjection(this IServiceCollection services)
		{
			IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>()!;
			var title = configuration.GetSection("ApplicationSettings").GetValue<string>("Title");
			var version = configuration.GetSection("ApplicationSettings").GetValue<string>("Version");




			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(setup =>
			{
				setup.SwaggerDoc("v1", new OpenApiInfo() { Title = title, Version = version });

				var securitySchems = new OpenApiSecurityScheme
				{
					Name = "JWT Autenticação",
					Description = "Entre com o JWT Bearer Token",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					BearerFormat = "JWT",
					Reference = new OpenApiReference
					{
						Id = JwtBearerDefaults.AuthenticationScheme,
						Type = ReferenceType.SecurityScheme
					}
				};

				setup.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchems);
				setup.AddSecurityRequirement(new OpenApiSecurityRequirement { { securitySchems, new string[] { } } });
			});

			return services;
		}


		public static IServiceCollection AddAuthenticationJWTBearer(this IServiceCollection services)
		{
			string secretKey = "eeccd01b-e77c-44f9-bb9f-a519b3105dce";

			services.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				}
			)
			.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = "Staris",
						ValidAudience = "Staris",
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
					};
				}
			);

			return services;
		}

	}
}
