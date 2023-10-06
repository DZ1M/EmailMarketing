using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailMarketing.Domain.Entities;

namespace EmailMarketing.Infra.Mappings
{
    public class UsuarioPermissaoConfiguration : IEntityTypeConfiguration<UsuarioPermissao>
    {
        public void Configure(EntityTypeBuilder<UsuarioPermissao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.IdPermissao)
                .HasColumnName("id_permissao");

            builder.Property(c => c.IdUsuario)
                .HasColumnName("id_usuario");

            builder.HasOne(c => c.Usuario)
                .WithMany(x => x.Permissoes)
                .HasForeignKey(c => c.IdUsuario);

            builder.HasOne(x => x.Permissao)
                .WithMany()
                .HasForeignKey(c => c.IdPermissao)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("usuarios_permissoes", "auth");
        }
    }
}
