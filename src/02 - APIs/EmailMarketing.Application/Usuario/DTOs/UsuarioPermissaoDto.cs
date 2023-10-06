using EmailMarketing.Domain.Entities;

namespace EmailMarketing.Application.DTOs
{
    public class UsuarioPermissaoDto
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdPermissao { get; set; }
        public static UsuarioPermissaoDto New(UsuarioPermissao role)
        {
            return new UsuarioPermissaoDto { 
                Id = role.Id,
                IdPermissao = role.IdPermissao,
                IdUsuario = role.IdUsuario
            };
        }
    }
}
