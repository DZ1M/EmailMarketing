using EmailMarketing.Architecture.Core.Utils;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.Usuario
{
    internal class UsuarioTestFixture : BaseFixture
    {
        public Entity.Usuario Novo()
        {
            return new Entity.Usuario(
                        nome: Faker.Name.FullName(),
                        email: Faker.Internet.Email(),
                        senha: Faker.Internet.Password(),
                        descricao: Faker.Lorem.Sentence(),
                        telefone: Faker.Phone.PhoneNumber(),
                        url: Faker.Internet.Url()
                    );
        }

        [CollectionDefinition(nameof(UsuarioTestFixture))]
        public class UsuarioTestFixtureCollection : ICollectionFixture<UsuarioTestFixture>
        { }
    }
}
