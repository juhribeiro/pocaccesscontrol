namespace accesscontrol.Util
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Cryptografy
    /// </summary>
    public static class Criptografy
    {
        private const string Salt = "@#$!¨**¨$#";

        /// <summary>
        /// Returns a MD5 Hash
        /// </summary>
        /// <param name="value">Value to Hash</param>
        /// <returns>String encoded</returns>
        private static string GetSha256Hash(this string value)
        {
            var hash = HashAlgorithm.Create("SHA-256");
            byte[] bytes = Encoding.ASCII.GetBytes(value);
            var data = hash.ComputeHash(bytes);
            var stringb = new StringBuilder();

            for (var i = 0; i < data.Length; i++)
            {
                stringb.Append(data[i].ToString("x2"));
            }

            return stringb.ToString();
        }

        public static string EncriptPassword(string email, string password)
        {
            return string.Format("#{0}¬¬{1}¬¬{2}#", email, password, Criptografy.Salt).GetSha256Hash();
        }
    }
}