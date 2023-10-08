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

            builder.Ignore(c => c.IdEmpresa);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");


            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.Excluido)
                .HasColumnName("excluido")
                .HasDefaultValue(false);


            builder.Property(x => x.CriadoEm)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("criado_em");

            builder.Property(x => x.AtualizadoEm)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("atualizado_em");
        }
    }
}
