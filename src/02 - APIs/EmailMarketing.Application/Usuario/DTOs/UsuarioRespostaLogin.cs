using EmailMarketing.Application.DTOs;

namespace EmailMarketing.Application.DTOs
{
    public class UsuarioRespostaLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
    }
}
