using EmailMarketing.Architecture.Core.Utils;
using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.Modelo
{
    internal class ModeloTestFixture : BaseFixture
    {
        public Entity.Modelo Novo()
        {
            return new Entity.Modelo(
                    nome: Faker.Company.CompanyName(),
                    texto: Faker.Lorem.Sentence(),
                    tipo: Faker.PickRandom<TipoMensagemEnum>(),
                    idEmpresa: Faker.Random.Guid(),
                    idUsuario: Faker.Random.Guid()
                );
        }

        [CollectionDefinition(nameof(ModeloTestFixture))]
        public class ModeloTestFixtureCollection : ICollectionFixture<ModeloTestFixture>
        { }
    }
}
