namespace EmailMarketing.Domain.Entities
{
    public class CampanhaPasta
    {
        protected CampanhaPasta() { }
        public CampanhaPasta(Guid idPasta)
        {
            PastaId = idPasta;
        }
        public Guid CampanhaId { get; private set; }
        public Campanha Campanha { get; private set; }
        public Guid PastaId { get; private set; }
        public Pasta Pasta { get; private set; }
    }
}
