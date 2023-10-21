using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.Infra.Seeds
{
    public static class PermissaoSeeder
    {
        public static void Seed(EntityTypeBuilder<Permissao> builder)
        {
            builder.HasData(

                new Permissao("Pasta", "Create"),
                new Permissao("Pasta", "Read"),
                new Permissao("Pasta", "Update"),
                new Permissao("Pasta", "Delete"),

                new Permissao("Modelo", "Create"),
                new Permissao("Modelo", "Read"),
                new Permissao("Modelo", "Update"),
                new Permissao("Modelo", "Delete"),

                new Permissao("Contato", "Create"),
                new Permissao("Contato", "Read"),
                new Permissao("Contato", "Update"),
                new Permissao("Contato", "Delete"),

                new Permissao("Campanha", "Create"),
                new Permissao("Campanha", "Read"),
                new Permissao("Campanha", "Update"),
                new Permissao("Campanha", "Delete")
                );
        }
    }
}
