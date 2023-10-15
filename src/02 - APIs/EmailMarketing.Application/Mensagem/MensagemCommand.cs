using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Domain.Enums;
using MediatR;

namespace EmailMarketing.Application.Mensagem
{
    public class MensagemCommand : Command, IRequest<Unit>
    {
        /// <summary>Nome da campanha</summary>
        /// <example>Leads</example>
        public string Nome { get; set; }
        /// <summary>Titulo do Email</summary>
        /// <example>@Nome - veja as novidades de hoje</example>
        public string Titulo { get; set; }
        /// <summary>Pastas</summary>
        /// <example>['2b4addd1-72d5-4258-bad3-42ff836d8f40','336fc47c-7cc6-48f3-b2ee-75d7d56d39a3']</example>
        public List<Guid> IdPastas { get; set; }
        /// <summary>Modelo</summary>
        /// <example>fb93e24e-7525-404f-a14c-005da9960eaf</example>
        public Guid IdModelo { get; set; }
        /// <summary>Tipo de Mensagem</summary>
        /// <example>Email</example>
        public TipoMensagemEnum Tipo { get; set; }
    }
}
