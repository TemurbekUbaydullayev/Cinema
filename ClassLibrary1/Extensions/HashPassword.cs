using System.Text;
using XSystem.Security.Cryptography;

namespace Cinema.Service.Extensions
{
    public static class HashPassword
    {
        public static string GetHashPassword(this string password)
        {

            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(password);

            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            StringBuilder stringOutput = new StringBuilder(tmpHash.Length);

            for (int i = 0; i < tmpHash.Length; i++)
            {
                stringOutput.Append(tmpHash[i].ToString("X2"));
            }

            return stringOutput.ToString();
        }
    }
}
