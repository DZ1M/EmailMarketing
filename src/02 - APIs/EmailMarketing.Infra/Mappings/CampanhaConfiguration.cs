using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace EmailMarketing.Infra.Mappings
{
    public class CampanhaConfiguration : IEntityTypeConfiguration<Campanha>
    {
        public void Configure(EntityTypeBuilder<Campanha> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.IdEmpresa)
                .HasColumnName("id_empresa")
                .IsRequired();

            builder.Property(x => x.CriadoEm)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("criado_em");

            builder.Property(c => c.CriadoPor)
                .HasColumnName("criado_por");

            builder.Property(x => x.AtualizadoEm)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("atualizado_em");

            builder.Property(c => c.AtualizadoPor)
                .HasColumnName("atualizado_por");

            builder.ToTable("campanhas", "marketing");
        }
    }
}
