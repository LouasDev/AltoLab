using System.Security.Cryptography;
using System.Text;

namespace AltoLab.Utils
{
    public static class SecurityUtils
    {
        public static string GerarHashSHA256(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
