namespace EmailMarketing.Domain.Entities
{
    public class ContatoPasta
    {
        public Guid ContatoId { get; set; }
        public Contato Contato { get; set; }
        public Guid PastaId { get; set; }
        public Pasta Pasta { get; set; }
    }
}
