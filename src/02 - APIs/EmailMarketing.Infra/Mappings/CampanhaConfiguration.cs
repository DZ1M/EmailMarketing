using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EmailMarketing.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

            builder.Property(c => c.TipoMensagem)
                .HasColumnName("tipo_mensagem")
                .HasColumnType("varchar(25)")
                .HasConversion(new EnumToStringConverter<TipoMensagemEnum>())
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar(250)");

            builder.Property(c => c.IdEmpresa)
                .HasColumnName("id_empresa")
                .IsRequired();

            builder.Property(c => c.IdModelo)
                .HasColumnName("id_modelo")
                .IsRequired();

            builder.Property(c => c.Data)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data")
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

            builder.HasMany(x => x.Contatos)
                .WithOne()
                .HasForeignKey(c => c.IdCampanha);

            builder.HasMany(x => x.Pastas)
                .WithOne(c => c.Campanha)
                .HasForeignKey(c => c.CampanhaId);

            builder.HasOne(x => x.Modelo)
                .WithMany()
                .HasForeignKey(c => c.IdModelo);

            builder.ToTable("campanhas", "marketing");
        }
    }
}
