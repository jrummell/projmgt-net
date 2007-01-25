using System;
using System.Security.Cryptography;
using System.Text;

namespace PMT.BLL
{
	public class Encryption
	{
        #region MD5
        /// <summary>
        /// A one way encryption using an MD5 Hash
        /// </summary>
        /// <param name="toEncrypt">string to encrypt</param>
        /// <returns>encrypted string</returns>
        public static string MD5Encrypt(string toEncrypt)
        {
            MD5 md5 = MD5.Create();
            string encrypted = BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(toEncrypt))).Replace("-", String.Empty).ToLower();
            return encrypted;
        }
        #endregion

        #region RSA
        /// <summary>
        /// Encrypt using RSA.  Can be decrypted with RsaDecrypt.
        /// </summary>
        /// <param name="s">string to encrypt</param>
        /// <returns>encrypted string</returns>
        public static string RsaEncrypt(string s)
        {
            RSA rsa = RSA.Create("Rijndael");
            return BitConverter.ToString(rsa.EncryptValue(Encoding.ASCII.GetBytes(s)));
        }

        /// <summary>
        /// Decrypt a string encrypted with RsaEncrypt.
        /// </summary>
        /// <param name="s">string to decrypt</param>
        /// <returns>decrypted string</returns>
        public static string RsaDecrypt(string s)
        {
            RSA rsa = RSA.Create("Rijndael");
            return BitConverter.ToString(rsa.EncryptValue(Encoding.ASCII.GetBytes(s)));
        }
        #endregion
	}
}
