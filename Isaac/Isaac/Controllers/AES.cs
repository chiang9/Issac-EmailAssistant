using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Isaac.Controllers
{

    class AES
    {
        public static string IV = "abced324dslkesor";
        public static string Key = "akdifosprnesiewjd234ewwdicdesaed";

        public static string Encrypt(string decrypted)
        {
            byte[] textbytes = ASCIIEncoding.ASCII.GetBytes(decrypted);
            AesCryptoServiceProvider encde = new AesCryptoServiceProvider();
            encde.BlockSize = 128;
            encde.KeySize = 256;
            encde.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            encde.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            encde.Padding = PaddingMode.PKCS7;
            encde.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = encde.CreateEncryptor(encde.Key, encde.IV);
            byte[] enc = icrypt.TransformFinalBlock(textbytes, 0, textbytes.Length);
            icrypt.Dispose();
            return Convert.ToBase64String(enc);
        }


        public static string Decrypt(string encrypted)
        {
            byte[] textbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider encde = new AesCryptoServiceProvider();
            encde.BlockSize = 128;
            encde.KeySize = 256;
            encde.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            encde.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            encde.Padding = PaddingMode.PKCS7;
            encde.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = encde.CreateDecryptor(encde.Key, encde.IV);
            byte[] dec = icrypt.TransformFinalBlock(textbytes, 0, textbytes.Length);
            icrypt.Dispose();
            return ASCIIEncoding.ASCII.GetString(dec);
        }
    }
}