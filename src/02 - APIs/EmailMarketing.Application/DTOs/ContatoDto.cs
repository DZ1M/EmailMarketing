namespace EmailMarketing.Application.DTOs
{
    public class ContatoDto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public static ContatoDto New(EmailMarketing.Domain.Entities.Contato entity)
        {
            return new ContatoDto
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Email = entity.Email,
                Telefone = entity.Telefone
            };
        }
    }
}
