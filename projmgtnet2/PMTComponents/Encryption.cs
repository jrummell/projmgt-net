using System;
using System.Security.Cryptography;
using System.Text;

namespace PMTComponents
{
	public class Encryption
	{
        /// <summary>
        /// Encrypt a users password
        /// </summary>
        /// <param name="toEncrypt">Password to encrypt</param>
        /// <returns>Encrypted password</returns>
        public static string encrypt(string toEncrypt)
        {
            MD5 md5 = MD5.Create();
            string encrypted = BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(toEncrypt))).Replace("-", String.Empty).ToLower();
            return encrypted;
        }
	}
}
