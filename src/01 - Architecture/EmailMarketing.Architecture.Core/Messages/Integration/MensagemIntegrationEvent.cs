namespace EmailMarketing.Architecture.Core.Messages.Integration
{
    public class MensagemIntegrationEvent : IntegrationEvent
    {
        public MensagemIntegrationEvent(Guid id, string nome, string email, string texto)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Texto = texto;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Texto { get; private set; }
    }
}
