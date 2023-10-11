using EmailMarketing.SenderMail.Domain.Entities;
using FluentAssertions;

namespace EmailMarketing.SenderMail.UnitTests.Domain.Entities
{
    [Collection(nameof(ControleEmailTestFixtureCollection))]
    public class ControleEmailTest
    {
        private readonly ControleEmailTestFixture _testFixture;
        public ControleEmailTest()
        {
            _testFixture = new ControleEmailTestFixture();
        }

        [Fact(DisplayName = nameof(CriarControleEmailValido))]
        [Trait("Domain", "Controle Email - Aggregates")]
        public void CriarControleEmailValido()
        {
            var obj = _testFixture.Novo();
            var objToCreate = new ControleEmail(
                    nome: obj.Nome,
                    email: obj.Email,
                    smtp: obj.Smtp,
                    porta: obj.Porta,
                    ssl: obj.Ssl,
                    usuario: obj.Usuario,
                    senha: obj.Senha,
                    data: obj.Data,
                    limiteDiario: obj.LimiteDiario,
                    idEmpresa: obj.IdEmpresa);

            objToCreate.Should().NotBeNull();
            objToCreate.Nome.Should().Be(obj.Nome);
            objToCreate.Email.Should().Be(obj.Email);
            objToCreate.Smtp.Should().Be(obj.Smtp);
            objToCreate.Porta.Should().Be(obj.Porta);
            objToCreate.Ssl.Should().Be(obj.Ssl);
            objToCreate.Usuario.Should().Be(obj.Usuario);
            objToCreate.Senha.Should().Be(obj.Senha);
            objToCreate.LimiteDiario.Should().Be(obj.LimiteDiario);
            objToCreate.IdEmpresa.Should().Be(obj.IdEmpresa);
            objToCreate.IdEmpresa.Should().NotBe(default(Guid));
            objToCreate.Data.Should().NotBe(default(DateTime));
            objToCreate.Id.Should().Be(default(Guid));
        }

        [Fact(DisplayName = nameof(AumentarLimite))]
        [Trait("Domain", "Controle Email - Aggregates")]
        public void AumentarLimite()
        {
            var obj = _testFixture.Novo();
            var objToUpdate = _testFixture.Novo();

            objToUpdate.AumentarEnviadosHoje();

            objToUpdate.EnviadosHoje.Should().Be(1);
            objToUpdate.EnviadosHoje.Should().NotBe(0);
            objToUpdate.EnviadosHoje.Should().NotBe(obj.EnviadosHoje);
        }
    }
}
