using System.Security.Cryptography;
using System.Text;

namespace E_Shop.Infra.Data.Security
{
    public static class PasswordHasher
    {
        public static string EncodePasswordMd5(this string pass)
        {
            //byte[] orginalBytes;
            //byte[] encodedBytes;
            //MD5 md5;
            //md5 = new MD5CryptoServiceProvider();
            //orginalBytes = ASCIIEncoding.Default.GetBytes(pass);
            //encodedBytes = md5.ComputeHash(orginalBytes);

            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            byte[] encodedBytes = MD5.HashData(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }
    }
}
