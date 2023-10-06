using EmailMarketing.Application.DTOs;
using EmailMarketing.Application.Usuario.Queries.BuscarPorEmail;
using EmailMarketing.Architecture.WebApi.Core.Auth;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmailMarketing.Application.Usuario.Queries.GerarJwt
{
    public class GerarTokenCommandHandler : IRequestHandler<GerarTokenCommand, UsuarioRespostaLogin>
    {
        private ISender _sender;
        private readonly AppSettings _appSettings;
        public GerarTokenCommandHandler(ISender sender, IOptions<AppSettings> appSettings)
        {
            _sender = sender;
            _appSettings = appSettings.Value;
        }

        public async Task<UsuarioRespostaLogin> Handle(GerarTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _sender.Send(new GetUsuarioByEmailQuery { Email = request.Email });

            var identityClaims = ObterClaimsUsuario(user, request.IdEmpresa);

            var encodedToken = CodificarToken(identityClaims);

            return ObterRespostaToken(encodedToken, user);
        }

        private ClaimsIdentity ObterClaimsUsuario(EmailMarketing.Domain.Entities.Usuario usuario, Guid idEmpresa)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim("Email", usuario.Email),
                new Claim(JwtRegisteredClaimNames.Name, usuario.Nome),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)
            };

            // Adiciona as Roles do usuario
            foreach (var userRole in usuario.Permissoes)
            {
                claims.Add(new Claim(userRole.Permissao.Nome, userRole.Permissao.Valor));
            }


            int indice = 1;
            foreach (var userEmpresa in usuario.Empresas)
            {
                if (usuario.Empresas.Count == 1)
                {
                    claims.Add(new Claim("Empresa", userEmpresa.IdEmpresa.ToString()));
                }
                else
                {
                    if (userEmpresa.IdEmpresa == idEmpresa)
                    {
                        claims.Add(new Claim("Empresa", userEmpresa.IdEmpresa.ToString()));
                    }
                    else
                    {
                        claims.Add(new Claim($"Empresa{indice}", userEmpresa.IdEmpresa.ToString()));
                        indice++;
                    }
                }
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }
        private string CodificarToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }
        private UsuarioRespostaLogin ObterRespostaToken(string encodedToken, EmailMarketing.Domain.Entities.Usuario usuario)
        {
            return new UsuarioRespostaLogin
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UsuarioToken = new UsuarioToken
                {
                    Name = usuario.Nome,
                    Id = usuario.Id.ToString(),
                    Email = usuario.Email,
                    Claims = usuario.Permissoes.Select(v => v.Permissao).Select(c => new UsuarioClaim { Type = c.Nome, Value = c.Valor })
                }
            };
        }
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

    }

}
