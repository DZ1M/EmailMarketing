using EmailMarketing.Domain.Entities;

namespace EmailMarketing.Application.DTOs
{
    public class EmpresaDto
    {
        public string Nome { get; set; }
        public Guid Id { get; set; }
        public static EmpresaDto New(Empresa empresa)
        {
            return new EmpresaDto
            {
                Nome = empresa.Nome,
                Id = empresa.Id,
            };
        }
    }
}
