using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DoIt.Core.Utilities
{
    public class HashHelper
    {
        public static string GetSha256(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                // Convert input string to byte array and compute the hash
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create StringBuilder to collect and create string
                StringBuilder builder = new StringBuilder();

                foreach (byte b in data)
                {
                    // Loop each byte of hashed data and create hexadecimal format string 
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static bool VerifyHash(string input, string hash)
        {
            // Create hash of input string
            string hashOfInput = GetSha256(input);

            // Compare hashes
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
