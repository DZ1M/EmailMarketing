using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Contato : Entity
    {
        protected Contato() { }
        public Contato(string? nome, string? email, string? telefone, Guid idEmpresa, Guid idUsuario)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;

            IdEmpresa = idEmpresa;
            CriadoEm = DateTime.Now;
            CriadoPor = idUsuario;
        }
        public void AddPasta(Guid idPasta)
        {
            if (ContatoPastas is null)
                ContatoPastas = new List<ContatoPasta>();

            ContatoPastas.Add(new ContatoPasta(idPasta));
        }
        public void Update(string? nome, string? email, string? telefone, Guid idUsuario)
        {
            if (nome is not null && Nome.Equals(nome) is not true) Nome = nome;
            if (email is not null && Email.Equals(email) is not true) Email = email;
            if (telefone is not null && Telefone.Equals(telefone) is not true) Telefone = telefone;

            AtualizadoEm = DateTime.Now;
            AtualizadoPor = idUsuario;
        }
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public string? Telefone { get; private set; }
        public ICollection<ContatoPasta> ContatoPastas { get; set; }
    }
}
