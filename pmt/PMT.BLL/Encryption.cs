using System;
using System.Security.Cryptography;
using System.Text;

namespace PMT.BLL
{
	internal static class Encryption
	{
        #region MD5
        /// <summary>
        /// A one way encryption using an MD5 Hash
        /// </summary>
        /// <param name="toEncrypt">string to encrypt</param>
        /// <returns>encrypted string</returns>
        public static string Encrypt(string toEncrypt)
        {
            MD5 md5 = MD5.Create();
            string encrypted = BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(toEncrypt))).Replace("-", String.Empty).ToLower();
            return encrypted;
        }
        #endregion
	}
}
