using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.Infra.Mappings
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Ignore(c => c.IdEmpresa);
            builder.Ignore(c => c.AtualizadoEm);
            builder.Ignore(c => c.CriadoPor);
            builder.Ignore(c => c.AtualizadoPor);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(c => c.Ativo)
                .HasColumnName("ativo");

            builder.Property(x => x.CriadoEm)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("criado_em");

            builder.ToTable("empresas", "auth");
        }
    }
}
