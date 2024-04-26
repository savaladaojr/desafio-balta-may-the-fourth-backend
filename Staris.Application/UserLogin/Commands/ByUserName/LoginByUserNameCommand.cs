using MediatR;
using Staris.Application.Shared.Responses;

namespace Staris.Application.UserLogin.Commands.ByUserName
{
    public sealed class LoginByUserNameCommand : IRequest<UserLoginResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
