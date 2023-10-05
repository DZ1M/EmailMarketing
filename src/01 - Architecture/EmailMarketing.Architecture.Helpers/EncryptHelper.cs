using System.Security.Cryptography;
using System.Text;

namespace EmailMarketing.Architecture.Helpers
{
    public static class EncryptHelper
    {
        public static string Sha256(this string valor)
        {
            using var sha256 = SHA256.Create();
            return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(valor))).Replace("-", "").ToLower();
        }
    }
}
