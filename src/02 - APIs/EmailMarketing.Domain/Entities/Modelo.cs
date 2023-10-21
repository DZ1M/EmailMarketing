using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Domain.Enums;

namespace EmailMarketing.Domain.Entities
{
    public class Modelo : Entity
    {
        protected Modelo() { }
        public string Nome { get; private set; }
        public string Texto { get; private set; }
        public TipoMensagemEnum Tipo { get; private set; }
        public Modelo(string nome, string texto, TipoMensagemEnum tipo, Guid idEmpresa, Guid idUsuario)
        {
            Nome = nome;
            Texto = texto;
            Tipo = tipo;

            CriadoEm = DateTime.Now;
            CriadoPor = idUsuario;
            IdEmpresa = idEmpresa;
        }
        public void Update(string? nome, string? texto, TipoMensagemEnum? tipo, Guid idUsuario)
        {

            if (nome is not null && Nome.Equals(nome) is not true) Nome = nome;
            if (texto is not null && Texto.Equals(texto) is not true) Texto = texto;
            if (tipo is not null && tipo.HasValue && Tipo != tipo) Tipo = tipo.Value;

            AtualizadoEm = DateTime.Now;
            AtualizadoPor = idUsuario;
        }
    }
}
