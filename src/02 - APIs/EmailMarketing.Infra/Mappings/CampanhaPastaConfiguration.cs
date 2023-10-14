using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.Infra.Mappings
{
    public class CampanhaPastaConfiguration : IEntityTypeConfiguration<CampanhaPasta>
    {
        public void Configure(EntityTypeBuilder<CampanhaPasta> builder)
        {
            builder.HasKey(up => new { up.CampanhaId, up.PastaId });

            builder.Property(c => c.CampanhaId)
                .HasColumnName("id_campanha");

            builder.Property(c => c.PastaId)
                .HasColumnName("id_pasta");

            builder.HasOne(up => up.Campanha)
                .WithMany(p => p.Pastas)
                .HasForeignKey(up => up.CampanhaId);

            builder.HasOne(up => up.Pasta)
                .WithMany()
                .HasForeignKey(up => up.PastaId);

            builder.ToTable("campanhas_pastas", "marketing");
        }
    }
}
