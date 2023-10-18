namespace EmailMarketing.Application.DTOs
{
    public class PastaDto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public static PastaDto New(EmailMarketing.Domain.Entities.Pasta entity)
        {
            return new PastaDto
            {
                Id = entity.Id,
                Nome = entity.Nome
            };
        }
    }
}
