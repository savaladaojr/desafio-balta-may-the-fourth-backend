using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Staris.Application.Shared.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Staris.Application.UseCases.UserLogin.Commands.ByUserName
{
    public sealed class LoginByUserNameCommandHandler : IRequestHandler<LoginByUserNameCommand, UserLoginResponse>
    {
        private readonly IMapper _mapper;

        public LoginByUserNameCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<UserLoginResponse> Handle(LoginByUserNameCommand request, CancellationToken cancellationToken)
        {
            string token = string.Empty;

            if (request.UserName == "admin" && request.Password == "12345678")
            {
                token = GerarTokenJwt();
            }

            return new UserLoginResponse() { Token = token, UserName = request.UserName };
        }

        private string GerarTokenJwt()
        {
            string securityKey = "eeccd01b-e77c-44f9-bb9f-a519b3105dce";

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login", "admin"),
                new Claim("nome", "System Administrator")
            };

            var token = new JwtSecurityToken(
                issuer: "Staris",
                audience: "Staris",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credencial
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
