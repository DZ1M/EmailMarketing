using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EmailMarketing.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmailMarketing.Infra.Mappings
{
    public class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.Texto)
                .HasColumnName("texto")
                .HasColumnType("text");

            builder.Property(c => c.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("varchar(25)")
                .HasConversion(new EnumToStringConverter<TipoMensagemEnum>())
                .IsRequired();

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

            builder.ToTable("modelos", "marketing");
        }
    }
}
