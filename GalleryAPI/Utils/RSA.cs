using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GalleryAPI.Utils
{
    public class RSA
    {
        /// <summary> 

        /// RSA encrypt data

        /// </summary> 

        /// <param name="express">the data you want to encrpt</param> 

        /// <param name="KeyContainerName">the name of the encrypt key</param> 

        /// <returns></returns> 

        public static string RSAEncryption(Object express, string KeyContainerName = null)

        {

            string strexpress = JsonSerializer.Serialize(express);

            System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();

            param.KeyContainerName = KeyContainerName ?? "CA_TEAM_1B"; //encrypt key container's name,should keep it consistent and the we can decrypt successfully

            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))

            {

                byte[] plaindata = System.Text.Encoding.Default.GetBytes(strexpress);//convert the express into byte array

                byte[] encryptdata = rsa.Encrypt(plaindata, false);//convert the encrypted byte array into new encryption byte array

                return Convert.ToBase64String(encryptdata);//convert te encryption byte array into string

            }

        }

        /// <summary> 

        /// RSA decrypt

        /// </summary> 

        /// <param name="express">string want to decrypt</param> 

        /// <param name="KeyContainerName">the name of the encrypt key</param> 

        /// <returns></returns> 

        public static Object RSADecrypt(string ciphertext, string KeyContainerName = null)

        {

            System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();

            param.KeyContainerName = KeyContainerName ?? "CA_TEAM_1B"; //encrypt key container's name,should keep it consistent and the we can decrypt successfully

            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))

            {

                byte[] encryptdata = Convert.FromBase64String(ciphertext);

                byte[] decryptdata = rsa.Decrypt(encryptdata, false);

                string strexpress = System.Text.Encoding.Default.GetString(decryptdata);

                return JsonSerializer.Deserialize<Object>(strexpress);

            }

        }
    }
}
