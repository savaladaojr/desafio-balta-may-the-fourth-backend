using FluentValidation;
using Staris.Application.UseCases.Films.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Application.UseCases.Characters.Commands.Create;

public sealed class FilmCreateCommandValidator : AbstractValidator<FilmCreateCommand>
{
    public FilmCreateCommandValidator()
    {


    }

}
