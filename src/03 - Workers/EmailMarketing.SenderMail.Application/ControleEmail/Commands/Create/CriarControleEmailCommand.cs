using MediatR;

namespace EmailMarketing.SenderMail.Application.ControleEmail.Commands.Create
{
    public class CriarControleEmailCommand : IRequest<Unit>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Smtp { get; set; }
        public int Porta { get; set; }
        public bool Ssl { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public int LimiteDiario { get; set; }
        public Guid IdEmpresa { get; set; }
    }
}
