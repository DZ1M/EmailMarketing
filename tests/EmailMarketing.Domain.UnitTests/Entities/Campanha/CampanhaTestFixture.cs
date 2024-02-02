using Bogus;
using EmailMarketing.Architecture.Core.Utils;
using EmailMarketing.Domain.Enums;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.Campanha
{
    public class CampanhaTestFixture : BaseFixture
    {
        public Entity.Campanha Novo()
        {
            return new Entity.Campanha(
                tipoMensagem: Faker.PickRandom<TipoMensagemEnum>(),
                nome: Faker.Name.FullName(),
                titulo: Faker.Lorem.Sentence(),
                data: Faker.Date.Recent(),
                idModelo: Faker.Random.Guid(),
                idEmpresa: Faker.Random.Guid(),
                idUsuario: Faker.Random.Guid()
              );
        }

        [CollectionDefinition(nameof(CampanhaTestFixture))]
        public class CampanhaTestFixtureCollection : ICollectionFixture<CampanhaTestFixture>
        { }
    }
}
