using Microsoft.Extensions.Configuration;

namespace EmailMarketing.SenderMail.Application.EnviarEmail
{
    public abstract class BaseMensagemCommand
    {
        private readonly IConfiguration _config;
        public BaseMensagemCommand(IConfiguration config)
        {
            _config = config;
        }
        public string GerarImagemDeRastreio(string codigo)
        {
            var imagemRastreio = $"<img border=0 width=1 alt='' height=1 src='{_config["URL_API"]}/{codigo}' style='display: none; width: 1px; height: 1px' />";

            return imagemRastreio;
        }
    }
}
