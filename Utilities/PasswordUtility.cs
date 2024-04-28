using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace BioKudi.Utilities
{
	public class PasswordUtility
	{
        private string keySafe;
        private string iv;

        public void SetKeySafe(string keySafe)
        {
            this.keySafe = keySafe;
        }
        public string GetKeySafe()
        {
            return this.keySafe;
        }
        public void SetIv(string iv)
        {
            this.iv = iv;
        }
        public string GetIv()
        {
            return this.iv;
        }
        public static byte[] GenerateRandomKey()
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.GenerateKey();
                return aesAlg.Key;
            }
        }

        // Encrypt a string using a key and iv. Return the encrypted data
        public string CreatePassword(string plainText)
        {
            SetKeySafe(Convert.ToBase64String(GenerateRandomKey()));
            using (Aes aesAlg = Aes.Create())
            {
                string key = GetKeySafe();
                aesAlg.Key = Convert.FromBase64String(key);
                aesAlg.GenerateIV();
                SetIv(Convert.ToBase64String(aesAlg.IV));
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    byte[] encryptedBytes = msEncrypt.ToArray();
                    string encryptedText = Convert.ToBase64String(encryptedBytes);
                    return encryptedText;
                }
            }
        }

        // Encrypt a string using an existing key and iv. Return the encrypted data
        public string VerifyPassword(string cipherText)
        {
            byte[] key = Convert.FromBase64String(GetKeySafe());
            byte[] iv = Convert.FromBase64String(GetIv());
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.IV = iv;
                aesAlg.Key = key;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(cipherText);
                        }
                    }
                    byte[] encryptedBytes = msEncrypt.ToArray();
                    string encryptedText = Convert.ToBase64String(encryptedBytes);
                    return encryptedText; 
                }
            }
        }
    }
}
