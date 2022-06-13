using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace Cinema.Service.Extensions
{
    public static class HashPassword
    {
        public static string GetHashPassword(this string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            var res = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Encoding.UTF8.GetString(res);
        }
    }
}
