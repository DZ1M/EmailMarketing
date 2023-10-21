using EmailMarketing.Domain.Enums;

namespace EmailMarketing.Application.DTOs
{
    public class ModeloDto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Texto { get; private set; }
        public TipoMensagemEnum Tipo { get; private set; }
        public static ModeloDto New(EmailMarketing.Domain.Entities.Modelo entity)
        {
            return new ModeloDto
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Texto = entity.Texto,
                Tipo = entity.Tipo
            };
        }
    }
}
