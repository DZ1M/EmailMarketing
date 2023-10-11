using EmailMarketing.Architecture.Core.Utils;
using EmailMarketing.SenderMail.Domain.Entities;

namespace EmailMarketing.SenderMail.UnitTests.Domain.Entities
{
    public class ControleEmailTestFixture : BaseFixture
    {
        public ControleEmail Novo()
        {
            return new ControleEmail(
                    nome: Faker.Name.FullName(),
                    email: Faker.Internet.Email(),
                    smtp: Faker.Random.String(),
                    porta: Faker.Random.Number(),
                    ssl: Faker.Random.Bool(),
                    usuario: Faker.Internet.Password(),
                    senha: Faker.Internet.Password(),
                    data: DateTime.Today.Date,
                    limiteDiario: 200,
                    idEmpresa: Faker.Random.Guid());
        }
    }
    [CollectionDefinition(nameof(ControleEmailTestFixture))]
    public class ControleEmailTestFixtureCollection : ICollectionFixture<ControleEmailTestFixture>
    { }
}
