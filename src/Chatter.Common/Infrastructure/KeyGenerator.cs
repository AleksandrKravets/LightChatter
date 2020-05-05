using System;
using System.Security.Cryptography;

namespace Chatter.Common.Infrastructure
{
    public static class KeyGenerator
    {
        public static string GenerateKey()
        {
            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            return Convert.ToBase64String(key);
        }
    }
}
