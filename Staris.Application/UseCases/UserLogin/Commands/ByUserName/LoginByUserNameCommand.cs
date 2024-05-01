using MediatR;
using Staris.Application.Shared.Responses;

namespace Staris.Application.UseCases.UserLogin.Commands.ByUserName
{
    public sealed class LoginByUserNameCommand : IRequest<UserLoginResponse>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
