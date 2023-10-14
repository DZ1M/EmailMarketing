using System.Runtime.Serialization;

namespace EmailMarketing.Domain.Enums
{
    public enum AcaoMensagemEnum
    {
        [EnumMember(Value = "Aguardando Envio")]
        AguardandoEnvio,
        [EnumMember(Value = "Erro ao Enviar")]
        ErroAoEnviar,
        [EnumMember(Value = "Entregue")]
        Entregue,
        [EnumMember(Value = "Lida")]
        Lida
    }
}
