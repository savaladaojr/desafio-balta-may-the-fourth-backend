using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Staris.Application.UseCases.UserLogin.Commands.ByUserName;
using System.Reflection;

namespace Staris.Application;

public static class ApplicationDependecyInjection
{
    /// <summary>
    /// Responsável por adicionar as dependências a serem resolvidas no projeto de infra
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

		//Adding Mediatr commands handlers
		services.AddMediatR(opt =>
		{
    		opt.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());

		});

		//Adding Fluent Validation
		services.AddScoped<IValidator<LoginByUserNameCommand>, LoginByUserNameCommandValidator>();

		return services;
    }
}
