using EmailMarketing.Domain.Enums;
using FluentAssertions;

namespace EmailMarketing.Domain.UnitTests.Enums
{
    public class TipoMensagemEnumTest
    {

        [Fact(DisplayName = nameof(WhatsAppStringToNumber))]
        [Trait("Domain", "TipoMensagemEnum - Aggregates")]
        public void WhatsAppStringToNumber()
        {
            var obj = Enum.Parse<TipoMensagemEnum>("WhatsApp");

            obj.Should().Be(TipoMensagemEnum.WhatsApp);
        }

        [Fact(DisplayName = nameof(WhatsAppNumberToString))]
        [Trait("Domain", "TipoMensagemEnum - Aggregates")]
        public void WhatsAppNumberToString()
        {
            var obj = TipoMensagemEnum.WhatsApp;

            obj.ToString().Should().Be("WhatsApp");
        }


        [Fact(DisplayName = nameof(EmailStringToNumber))]
        [Trait("Domain", "TipoMensagemEnum - Aggregates")]
        public void EmailStringToNumber()
        {
            var obj = Enum.Parse<TipoMensagemEnum>("Email");

            obj.Should().Be(TipoMensagemEnum.Email);
        }

        [Fact(DisplayName = nameof(EmailNumberToString))]
        [Trait("Domain", "TipoMensagemEnum - Aggregates")]
        public void EmailNumberToString()
        {
            var obj = TipoMensagemEnum.Email;

            obj.ToString().Should().Be("Email");
        }


        [Fact(DisplayName = nameof(SMSStringToNumber))]
        [Trait("Domain", "TipoMensagemEnum - Aggregates")]
        public void SMSStringToNumber()
        {
            var obj = Enum.Parse<TipoMensagemEnum>("SMS");

            obj.Should().Be(TipoMensagemEnum.SMS);
        }

        [Fact(DisplayName = nameof(SMSNumberToString))]
        [Trait("Domain", "TipoMensagemEnum - Aggregates")]
        public void SMSNumberToString()
        {
            var obj = TipoMensagemEnum.SMS;

            obj.ToString().Should().Be("SMS");
        }

    }
}
