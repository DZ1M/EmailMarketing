using EmailMarketing.Domain.Enums;
using FluentAssertions;
using System.Runtime.Serialization;

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
        [Fact(DisplayName = nameof(EnumDeveTerValorAguardandoEnvio))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void EnumDeveTerValorAguardandoEnvio()
        {
            var valorEnum = AcaoMensagemEnum.AguardandoEnvio;

            var membro = typeof(AcaoMensagemEnum).GetField(valorEnum.ToString());
            var atributo = membro.GetCustomAttributes(typeof(EnumMemberAttribute), false);

            atributo.Should().HaveCount(1);
            atributo.Should().ContainSingle().Which.As<EnumMemberAttribute>().Value.Should().Be("Aguardando Envio");
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

        [Fact(DisplayName = nameof(EnumDeveTerValorErroAoEnviar))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void EnumDeveTerValorErroAoEnviar()
        {
            var valorEnum = AcaoMensagemEnum.ErroAoEnviar;

            var membro = typeof(AcaoMensagemEnum).GetField(valorEnum.ToString());
            var atributo = membro.GetCustomAttributes(typeof(EnumMemberAttribute), false);

            //Assert.Single(atributo);
            //Assert.Equal("Erro ao Enviar", ((EnumMemberAttribute)atributo[0]).Value);

            atributo.Should().HaveCount(1);
            atributo.Should().ContainSingle().Which.As<EnumMemberAttribute>().Value.Should().Be("Erro ao Enviar");
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
        [Fact(DisplayName = nameof(EnumDeveTerValorEntregue))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void EnumDeveTerValorEntregue()
        {
            var valorEnum = AcaoMensagemEnum.Entregue;

            var membro = typeof(AcaoMensagemEnum).GetField(valorEnum.ToString());
            var atributo = membro.GetCustomAttributes(typeof(EnumMemberAttribute), false);

            atributo.Should().HaveCount(1);
            atributo.Should().ContainSingle().Which.As<EnumMemberAttribute>().Value.Should().Be("Entregue");
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

        [Fact(DisplayName = nameof(EnumDeveTerValorLida))]
        [Trait("Domain", "AcaoMensagemEnum - Aggregates")]
        public void EnumDeveTerValorLida()
        {
            var valorEnum = AcaoMensagemEnum.Lida;

            var membro = typeof(AcaoMensagemEnum).GetField(valorEnum.ToString());
            var atributo = membro.GetCustomAttributes(typeof(EnumMemberAttribute), false);

            atributo.Should().HaveCount(1);
            atributo.Should().ContainSingle().Which.As<EnumMemberAttribute>().Value.Should().Be("Lida");
        }
    }
}
