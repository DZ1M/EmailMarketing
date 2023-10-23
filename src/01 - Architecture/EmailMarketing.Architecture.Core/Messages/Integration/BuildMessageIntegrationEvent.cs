namespace EmailMarketing.Architecture.Core.Messages.Integration
{
    public class BuildMessageIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public BuildMessageIntegrationEvent(Guid id, Guid idEmpresa)
        {
            Id = id;
            IdEmpresa = idEmpresa;
        }
    }
}
