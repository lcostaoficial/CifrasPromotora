using System.Security.Cryptography;
using System.Text;

namespace CIFRAS.Domain.Helpers
{
    public static class ConverterExtension
    {
        public static string CalculateMD5Hash(this string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = MD5.Create().ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}