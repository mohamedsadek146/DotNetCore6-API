using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNetCore6.Helpers
{
    public class SecurityHelper
    {
        private string allChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890@#$";
        private const string _alg = "HmacSHA256";
        private const string _salt = "Ac7k85rzat9tmmaFxDGmQgbrTgwvHJyt"; // Generated at https://www.random.org/strings
        //MAS2213
        #region Tokens
        
        public static string GenerateSalt()
        {
            int saltLength = 16;
            byte[] salt = new byte[saltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < salt.Length; i++)
            {
                builder.Append(salt[i].ToString("x2"));
            }
            return builder.ToString(); ;
        }
        public static bool ValidatePassword(string password, string salt, string hashedPassword)
        {
            return GetHashedPassword(password + salt) == hashedPassword;
        }
        public static string GetHashedPassword(string password, string salt = "")
        {
            if (string.IsNullOrEmpty(salt))
                salt = _salt;
            string key = string.Join(":", new string[] { password, salt });
            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                // Hash the key.
                hmac.Key = Encoding.UTF8.GetBytes(_salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));
                return Convert.ToBase64String(hmac.Hash);
            }
        }

        #endregion

        #region Encryption & Decryption


        public static string Encrypt(string text, string salt = "")
        {
            if (!string.IsNullOrEmpty(salt))
                salt = _salt;
            string result;
            if (text == "")
            {
                result = "";
            }
            else
            {

                UTF8Encoding uTF8Encoding = new UTF8Encoding();
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(salt));
                TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                tripleDESCryptoServiceProvider.Key = key;
                tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
                tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
                byte[] bytes = uTF8Encoding.GetBytes(text);
                byte[] inArray;
                try
                {
                    ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
                    inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
                }
                finally
                {
                    tripleDESCryptoServiceProvider.Clear();
                    mD5CryptoServiceProvider.Clear();
                }
                result = Convert.ToBase64String(inArray);
            }
            return result;
        }

        public static string Decrypt(string text, string salt = "")
        {
            if (!string.IsNullOrEmpty(salt))
                salt = _salt;
            string result;
            if (string.IsNullOrEmpty(text))
            {
                result = "";
            }
            else
            {
                UTF8Encoding uTF8Encoding = new UTF8Encoding();
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(salt));
                TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                tripleDESCryptoServiceProvider.Key = key;
                tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
                tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
                byte[] array = Convert.FromBase64String(text);
                byte[] bytes;
                try
                {
                    ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
                    bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
                }
                catch (Exception ex)
                {
                    bytes = null;
                }
                finally
                {
                    tripleDESCryptoServiceProvider.Clear();
                    mD5CryptoServiceProvider.Clear();
                }
                result = uTF8Encoding.GetString(bytes);
            }
            return result;
        }
        /// <summary>
        /// Generates a Random Password
        /// respecting the given strength requirements.
        /// </summary>
        /// <param name="opts">A valid PasswordOptions object
        /// containing the password strength requirements.</param>
        /// <returns>A random password</returns>
        // <summary>
        /// Generate passwords
        /// </summary>
        /// <param name="passwordLength"></param>
        /// <param name="strongPassword"> </param>
        /// <returns></returns>
        public static string PasswordGenerator(int passwordLength = 10, bool strongPassword = true)
        {
            Random Random = new Random();
            int seed = Random.Next(1, int.MaxValue);
            //const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            const string specialCharacters = @"!#$%&'()*+,-./:;<=>?@[\]_";

            var chars = new char[passwordLength];
            var rd = new Random(seed);

            for (var i = 0; i < passwordLength; i++)
            {
                // If we are to use special characters
                if (strongPassword && i % Random.Next(3, passwordLength) == 0)
                {
                    chars[i] = specialCharacters[rd.Next(0, specialCharacters.Length)];
                }
                else
                {
                    chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
                }
            }

            return new string(chars);
        }
        public static bool IsStrongPassword(string password)
        {
            string pattern = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,15}$";
            bool result;
            try
            {
                Regex.Match("", pattern);
            }
            catch (ArgumentException)
            {
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        #endregion
    }
}
