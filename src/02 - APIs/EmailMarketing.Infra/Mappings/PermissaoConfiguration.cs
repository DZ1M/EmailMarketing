using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.Infra.Mappings
{
    public class PermissaoConfiguration : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Ignore(c => c.IdEmpresa);
            builder.Ignore(c => c.CriadoEm);
            builder.Ignore(c => c.AtualizadoEm);
            builder.Ignore(c => c.CriadoPor);
            builder.Ignore(c => c.AtualizadoPor);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(c => c.Valor)
                .HasColumnName("valor")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Default)
                .HasColumnName("default_role")
                .IsRequired();

            builder.ToTable("permissoes", "auth");
        }
    }
}
