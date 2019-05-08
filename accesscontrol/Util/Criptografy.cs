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
        public const string Salt = "@#$!¨**¨$#";
        private const string EncryptKey = "@ac3'#=¬¬";

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

        /// <summary>
        /// Decrypt a value (with a private key)
        /// </summary>
        /// <param name="value">Value to decrypt</param>
        /// <param name="key">key of decrypt</param>
        /// <returns>Value decrypted</returns>
        public static string SymmetricDecrypt(this string value, string key)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            var aesDesProvider = GetAesCryptoServiceProvider(key);
            var valueArray = Convert.FromBase64String(value);
            var decryptor = aesDesProvider.CreateDecryptor();
            var resultArray = decryptor.TransformFinalBlock(valueArray, 0, valueArray.Length);

            aesDesProvider.Clear();

            var result = UTF8Encoding.UTF8.GetString(resultArray);
            return result;
        }

        private static AesCryptoServiceProvider GetAesCryptoServiceProvider(string key = null)
        {
            var sha256 = new SHA256Managed();
            var aesProvider = new AesCryptoServiceProvider();
            aesProvider.Key = sha256.ComputeHash(Encoding.UTF8.GetBytes(string.Format("{0}{1}", EncryptKey, key)));
            aesProvider.Mode = CipherMode.ECB;
            aesProvider.Padding = PaddingMode.PKCS7;

            sha256.Clear();

            return aesProvider;
        }

        public static string EncriptPassword(string email, string password)
        {
            return string.Format("{0}#{1}#{2}#{3}", email, password, Criptografy.Salt, DateTime.UtcNow.ToString("dd/MM/yyyy hh:mm:ss")).GetSha256Hash();
        }
    }
}