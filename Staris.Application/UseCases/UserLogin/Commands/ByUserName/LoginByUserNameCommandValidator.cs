using FluentValidation;
using MediatR;
using Staris.Application.Shared.Responses;

namespace Staris.Application.UseCases.UserLogin.Commands.ByUserName
{
    public sealed class LoginByUserNameCommandValidator : AbstractValidator<LoginByUserNameCommand>
    {
        public LoginByUserNameCommandValidator()
        {
            RuleFor(p => p.UserName)
               .NotEmpty().WithMessage("A User Name is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A Password is required")
                .MinimumLength(8).WithMessage("The password needs to have at leaset 8 chars.");
        }

    }
}
