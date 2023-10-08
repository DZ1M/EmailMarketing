using MediatR;

namespace EmailMarketing.SenderMail.Application.EnviarEmail
{
    public class EnviarMensagemCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Texto { get; set; }
        public string Codigo { get; set; }
        public Guid IdEmpresa { get; set; }
        public EnviarMensagemCommand(string nome, string email, string texto, string codigo, Guid idEmpresa)
        {
            Nome = nome;
            Email = email;
            Texto = texto;
            Codigo = codigo;
            IdEmpresa = idEmpresa;
        }
    }
}
