using EmailMarketing.Architecture.Core.Utils;
using EmailMarketing.Domain.Enums;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.CampanhaContatoAcao
{
    internal class CampanhaContatoAcaoTestFixture : BaseFixture
    {
        public Entity.CampanhaContatoAcao Novo()
        {
            return new Entity.CampanhaContatoAcao(
                    idCampanhaContato: Faker.Random.Guid(),
                    acao: Faker.PickRandom<AcaoMensagemEnum>()
                );
        }

        [CollectionDefinition(nameof(CampanhaContatoAcaoTestFixture))]
        public class CampanhaContatoAcaoTestFixtureCollection : ICollectionFixture<CampanhaContatoAcaoTestFixture>
        { }
    }
}
