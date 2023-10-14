namespace EmailMarketing.Domain.Entities
{
    public class CampanhaPasta
    {
        public Guid CampanhaId { get; set; }
        public Campanha Campanha { get; set; }
        public Guid PastaId { get; set; }
        public Pasta Pasta { get; set; }
    }
}
