using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EmailMarketing.Architecture.WebApi.Core.Usuario
{
    public interface IAspNetUser
    {
        string Name { get; }
        Guid ObterUserId();
        Guid ObterUserIdEmpresa();
        string ObterUserEmail();
        string ObterUserToken();
        string GetUserRefreshToken();
        bool EstaAutenticado();
        bool PossuiRole(string role);
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterHttpContext();
    }
}
