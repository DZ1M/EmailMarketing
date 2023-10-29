using EmailMarketing.Domain.Enums;
using FluentAssertions;

namespace EmailMarketing.Domain.UnitTests.Enums
{
    public class AcaoMensagemEnumTest
    {

        [Fact(DisplayName = nameof(AguardandoEnvioStringToNumber))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void AguardandoEnvioStringToNumber()
        {
            var obj = Enum.Parse<AcaoMensagemEnum>("AguardandoEnvio");

            obj.Should().Be(AcaoMensagemEnum.AguardandoEnvio);
        }

        [Fact(DisplayName = nameof(AguardandoEnvioNumberToString))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void AguardandoEnvioNumberToString()
        {
            var obj = AcaoMensagemEnum.AguardandoEnvio;

            obj.ToString().Should().Be("AguardandoEnvio");
        }


        [Fact(DisplayName = nameof(ErroAoEnviarStringToNumber))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void ErroAoEnviarStringToNumber()
        {
            var obj = Enum.Parse<AcaoMensagemEnum>("ErroAoEnviar");

            obj.Should().Be(AcaoMensagemEnum.ErroAoEnviar);
        }

        [Fact(DisplayName = nameof(ErroAoEnviarNumberToString))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void ErroAoEnviarNumberToString()
        {
            var obj = AcaoMensagemEnum.ErroAoEnviar;

            obj.ToString().Should().Be("ErroAoEnviar");
        }


        [Fact(DisplayName = nameof(EntregueStringToNumber))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void EntregueStringToNumber()
        {
            var obj = Enum.Parse<AcaoMensagemEnum>("Entregue");

            obj.Should().Be(AcaoMensagemEnum.Entregue);
        }

        [Fact(DisplayName = nameof(EntregueNumberToString))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void EntregueNumberToString()
        {
            var obj = AcaoMensagemEnum.Entregue;

            obj.ToString().Should().Be("Entregue");
        }

        [Fact(DisplayName = nameof(LidaStringToNumber))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void LidaStringToNumber()
        {
            var obj = Enum.Parse<AcaoMensagemEnum>("Lida");

            obj.Should().Be(AcaoMensagemEnum.Lida);
        }

        [Fact(DisplayName = nameof(LidaNumberToString))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void LidaNumberToString()
        {
            var obj = AcaoMensagemEnum.Lida;

            obj.ToString().Should().Be("Lida");
        }
    }
}
