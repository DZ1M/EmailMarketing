using System.IdentityModel.Tokens.Jwt;

namespace EmailMarketing.Architecture.WebApi.Core.Auth
{
    public static class JwtOptions
    {
        public static bool Expired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            if (DateTime.UtcNow > jwt.ValidTo)
            {
                return true;
            }
            return false;
        }
        public static string GetEmail(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

            if (jwt.Claims.Count(claim => claim.Type == "sub") > 0)
            {
                return jwt.Claims.First(claim => claim.Type == "Email").Value;
            }

            return "";
        }
        public static Guid GetIdEmpresa(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

            if (jwt.Claims.Count(claim => claim.Type == "sub") > 0)
            {
                var sub = jwt.Claims.First(claim => claim.Type == "Empresa").Value;
                Guid.TryParse(sub, out Guid idEmpresa);
                return idEmpresa;
            }

            return Guid.Empty;
        }
    }
}
