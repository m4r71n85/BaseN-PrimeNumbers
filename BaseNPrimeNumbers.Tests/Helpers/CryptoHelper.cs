using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BaseNPrimeNumbers.Tests.Helpers
{
    public class CryptoHelper
    {
        public static string GetMd5Hash(string text)
        {
            string hash;
            using (MD5 md5 = MD5.Create())
            {

                var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(text))
                 .Select(x => x.ToString("x2"));
                hash = string.Join(string.Empty, hashBytes);
            }

            return hash;
        }
    }
}
