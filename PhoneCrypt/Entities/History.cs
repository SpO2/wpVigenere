using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCrypt.Entities
{
    /// <summary>
    /// Entity Class for the History table. Stores Words and password.
    /// </summary>
    public class History
    {
        private const String IMG_ENCRYPT_URI = "Assets/crypted.png";
        private const String IMG_DECRYPT_URI = "Assets/decrypted.png";

        /// <summary>
        /// Id of the History entity.
        /// </summary>
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int id {get; set;}
        /// <summary>
        /// Create date of the History entity.
        /// </summary>
        public String createdAt { get; set; }
        /// <summary>
        /// Value of the words encrypted.
        /// </summary>
        public String value { get; set; }
        /// <summary>
        /// Password used to encrypt the word.
        /// </summary>
        public String password { get; set; }
        /// <summary>
        /// Specify the orientation of encryption (encrypt = 0 / decrypt = 1).
        /// </summary>
        public int orientation { get; set; }
        /// <summary>
        /// The URI of the orientation image to display.
        /// </summary>
        [SQLite.Ignore]
        public String imgOrientation { get; set; } 

        /// <summary>
        /// Default constructor.
        /// </summary>
        public History()
        {
            this.createdAt = DateTime.Now.ToString();
        }

        public void setOrientationImg(int orientation)
        {
            switch(orientation)
            {
                case 0: this.imgOrientation = IMG_ENCRYPT_URI;
                    break;
                case 1: this.imgOrientation = IMG_DECRYPT_URI;
                    break;
                default: this.imgOrientation = IMG_ENCRYPT_URI;
                    break;
            }
        }

        /// <summary>
        /// Constructor for an History entity.
        /// </summary>
        /// <param name="value">Value of the words encrypted.</param>
        /// <param name="password">Password used to encrypt the word.</param>
        public History(String value, String password, int orientation)
        {
            this.value = value;
            this.password = password;
            this.createdAt = DateTime.Now.ToString();
            this.orientation = orientation;
        }
    }
}
