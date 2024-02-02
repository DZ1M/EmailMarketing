using EmailMarketing.Architecture.Core.Utils;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.Pasta
{
    internal class PastaTestFixture : BaseFixture
    {
        public Entity.Pasta Novo()
        {
            return new Entity.Pasta(
                nome: Faker.Lorem.Word(),
                idEmpresa: Faker.Random.Guid(),
                idUsuario: Faker.Random.Guid()
                );
        }

        [CollectionDefinition(nameof(PastaTestFixture))]
        public class PastaTestFixtureCollection : ICollectionFixture<PastaTestFixture>
        { }
    }
}
