using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmailMarketing.Domain.Entities
{
    public class UsuarioPermissao
    {
        protected UsuarioPermissao() { }
        public UsuarioPermissao(Guid idUsuario, Guid idPermissao)
        {
            IdUsuario = idUsuario;
            IdPermissao = idPermissao;
        }

        public Guid Id { get; set; }
        public Guid IdUsuario { get; private set; }
        public Guid IdPermissao { get; private set; }
        [JsonIgnore]
        public Usuario Usuario { get; set; }
        [JsonIgnore]
        public Permissao Permissao { get; set; }
    }
}
