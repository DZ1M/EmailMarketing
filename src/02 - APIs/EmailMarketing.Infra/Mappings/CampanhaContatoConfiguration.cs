using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.Infra.Mappings
{
    public class CampanhaContatoConfiguration : IEntityTypeConfiguration<CampanhaContato>
    {
        public void Configure(EntityTypeBuilder<CampanhaContato> builder)
        {
            builder.Ignore(c => c.IdEmpresa);
            builder.Ignore(c => c.CriadoPor);
            builder.Ignore(c => c.AtualizadoPor);
            builder.Ignore(c => c.AtualizadoEm);

            builder.HasKey(x => x.Id);

            builder.HasIndex(c => c.Codigo).IsUnique();

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("varchar(150)");

            builder.Property(c => c.IdCampanha)
                .HasColumnName("id_mensagem")
                .IsRequired();

            builder.Property(c => c.IdContato)
                .HasColumnName("id_contato")
                .IsRequired();

            builder.Property(x => x.CriadoEm)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("criado_em");

            builder.HasMany(x => x.Acoes)
                .WithOne()
                .HasForeignKey(c => c.IdCampanhaContato);

            builder.HasOne(x => x.Campanha)
                .WithMany(c => c.Contatos)
                .HasForeignKey(x => x.IdCampanha);

            builder.HasOne(x => x.Contato)
                .WithMany()
                .HasForeignKey(c => c.IdContato);

            builder.ToTable("campanhas_contatos", "marketing");
        }
    }
}
