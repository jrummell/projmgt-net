using System;

namespace PMT
{
	/// <summary>
	/// Summary description for Encryption.
	/// </summary>
	public class Encryption
	{
        /// <summary>
        /// Encrypt the users password
        /// </summary>
        /// <param name="toEncrypt">Password to encrypt</param>
        /// <returns>Encrypted password</returns>
        public static string encrypt(string toEncrypt)
        {
            System.Security.Cryptography.MD5 md5=System.Security.Cryptography.MD5.Create();
            string encrypted=BitConverter.ToString(md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(toEncrypt))).Replace("-", String.Empty).ToLower();
            return encrypted;
        }
	}
}
