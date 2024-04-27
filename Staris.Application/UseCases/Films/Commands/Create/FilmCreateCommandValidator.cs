using FluentValidation;
using Staris.Application.UseCases.Planets.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Application.UseCases.Films.Commands.Create;

public sealed class FilmCreateCommandValidator : AbstractValidator<FilmCreateCommand>
{
    public FilmCreateCommandValidator()
    {


    }

}
