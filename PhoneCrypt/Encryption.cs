using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCrypt
{
    /// <summary>
    /// Class - Control the encryption/decryption.
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// String to encrypt/Decrypt.
        /// </summary>
        private String value;
        /// <summary>
        /// Encryption/Decryption key.
        /// </summary>
        private String passPhrase;

        /// <summary>
        /// Constructor for the encryption object.
        /// </summary>
        /// <param name="value">String to encrypt/decrypt.</param>
        /// <param name="passPhrase">Key for the encryption/decryption.</param>
        public Encryption(String value, String passPhrase)
        {
            this.value = value;
            this.passPhrase = passPhrase;
        }

        /// <summary>
        /// Encrypt/Decrypt the data.
        /// </summary>
        /// <param name="orientation">Specify the orientation of the encryption process (Encryption = 1, Decryption = -1).</param>
        /// <returns>The encrypted/decrypted data.</returns>
        private String encryptVigenere(int orientation)
        {
            int pwi = 0, tmp;
            string ns = "";
            String currentValue = this.value.ToUpper();
            String currentPassPhrase = this.passPhrase.ToUpper();
            if (currentValue != "" && currentPassPhrase != "")
            {
                foreach (char t in currentValue)
                {
                    if (t < 65) continue;
                    if (t > 90) continue;
                    tmp = t - 65 + orientation * (currentPassPhrase[pwi] - 65);
                    if (tmp < 0) tmp += 26;
                    ns += Convert.ToChar(65 + (tmp % 26));
                    if (++pwi == currentPassPhrase.Length) pwi = 0;
                }
            }
            return ns;
        }

        /// <summary>
        /// Encrypt a the value using the passPhrase.
        /// </summary>
        /// <returns>The encrypted data.</returns>
        public String encrypt()
        {
            return this.encryptVigenere(1);
        }

        /// <summary>
        /// Decrypt the value using the passPhrase.
        /// </summary>
        /// <returns>The decrypted data.</returns>
        public String decrypt()
        {
            return this.encryptVigenere(-1);
        }
    }
}
