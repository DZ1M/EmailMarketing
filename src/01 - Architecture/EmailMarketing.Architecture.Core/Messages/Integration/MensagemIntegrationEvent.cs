namespace EmailMarketing.Architecture.Core.Messages.Integration
{
    public class MensagemIntegrationEvent : IntegrationEvent
    {
        public MensagemIntegrationEvent(Guid id, string nome, string email, string texto, string codigo, Guid idEmpresa)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Texto = texto;
            Codigo = codigo;
            IdEmpresa = idEmpresa;
        }

        public Guid Id { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Texto { get; private set; }
        public string Codigo {  get; private set; }
    }
}
