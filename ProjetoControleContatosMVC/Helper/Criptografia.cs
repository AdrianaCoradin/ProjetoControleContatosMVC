using System.Security.Cryptography;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace ProjetoControleContatosMVC.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var ecoding = new ASCIIEncoding();
            var array = ecoding.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach(var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }
            return strHexa.ToString();
        }
    }
}
