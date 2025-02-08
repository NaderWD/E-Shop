using System.Security.Cryptography;
using System.Text;

namespace E_Shop.Application.Tools
{
    public static class PasswordHasher
    {
        public static string EncodePasswordMd5(this string pass)
        {
            byte[] originalBytes = Encoding.Default.GetBytes(pass);
            byte[] encodedBytes = MD5.HashData(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }
    }
}
