using System;
using System.Security.Cryptography;
using System.Text;

namespace testweb2
{
    public class Encryption
    {
        static public string Encode(string phrase)
        {
            int euckrCodepage = 51949;
            Encoding encoder = Encoding.GetEncoding(euckrCodepage);

            SHA256CryptoServiceProvider sha256hasher = new SHA256CryptoServiceProvider();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(phrase));

            string hashString = string.Empty;

            foreach (byte x in hashedDataBytes)
            {
                hashString += String.Format("{0:x2}", x);
            }

            return Convert.ToBase64String(encoder.GetBytes(hashString));
        }
    }
}