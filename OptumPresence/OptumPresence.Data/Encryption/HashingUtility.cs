using System.Text;
using System.Security.Cryptography;

namespace OptumPresence.Data.Encryption
{
    /// <summary>
    /// Utility class for hashing data for security.
    /// </summary>
    public class HashingUtility
    {
        /// <summary>
        /// Generate md5 hash of string input.
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMd5Hash(string input)
        {
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            using (var md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                
                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


    }
}
