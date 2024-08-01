using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AndroidBinderator
{
    internal static class Util
    {
        internal static string HashMd5(Stream value)
        {
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms - This is not used for cryptographic purposes
	    using (var md5 = MD5.Create())
	        return BitConverter.ToString(md5.ComputeHash(value)).Replace("-", "").ToLowerInvariant();
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms
	}

        internal static string HashSha256(string value)
        {
            return HashSha256(Encoding.UTF8.GetBytes(value));
        }

        internal static string HashSha256(byte[] value)
        {
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            using (var sha256 = new SHA256Managed())
            {
                var hash = new StringBuilder();
                var hashData = sha256.ComputeHash(value);
                foreach (var b in hashData)
                    hash.Append(b.ToString("x2"));

                return hash.ToString();
            }
#pragma warning restore SYSLIB0021 // Type or member is obsolete
		}

        internal static string HashSha256(Stream value)
        {
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            using (var sha256 = new SHA256Managed())
            {
                var hash = new StringBuilder();
                var hashData = sha256.ComputeHash(value);
                foreach (var b in hashData)
                    hash.Append(b.ToString("x2"));

                return hash.ToString();
            }
#pragma warning restore SYSLIB0021 // Type or member is obsolete
		}
    }
}
