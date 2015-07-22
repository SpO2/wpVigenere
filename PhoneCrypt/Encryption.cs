using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCrypt
{
    public class Encryption
    {
        private String value;
        private String passPhrase;

        public Encryption(String value, String passPhrase)
        {
            this.value = value;
            this.passPhrase = passPhrase;
        }

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

        public String encrypt()
        {
            return this.encryptVigenere(1);
        }

        public String decrypt()
        {
            return this.encryptVigenere(-1);
        }
    }
}
