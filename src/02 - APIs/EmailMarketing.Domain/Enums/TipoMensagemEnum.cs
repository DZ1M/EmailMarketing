using System.Runtime.Serialization;

namespace EmailMarketing.Domain.Enums
{
    public enum TipoMensagemEnum
    {
        [EnumMember(Value = "Email")]
        Email,
        [EnumMember(Value = "SMS")]
        SMS,
        [EnumMember(Value = "WhatsApp")]
        WhatsApp
    }
}
