using EmailMarketing.Architecture.Core.Utils;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.Contato
{
    internal class ContatoTestFixture : BaseFixture
    {
        public Entity.Contato Novo()
        {
            return new Entity.Contato(
                nome: Faker.Name.FullName(),
                email: Faker.Internet.Email(),
                telefone: Faker.Phone.PhoneNumber(),
                idEmpresa: Faker.Random.Guid(),
                idUsuario: Faker.Random.Guid()
            );
        }

        [CollectionDefinition(nameof(ContatoTestFixture))]
        public class ContatoTestFixtureCollection : ICollectionFixture<ContatoTestFixture>
        { }
    }
}
