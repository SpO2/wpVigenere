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
        /// Default constructor.
        /// </summary>
        public History()
        {
            this.createdAt = DateTime.Now.ToString();
        }

        /// <summary>
        /// Constructor for an History entity.
        /// </summary>
        /// <param name="value">Value of the words encrypted.</param>
        /// <param name="password">Password used to encrypt the word.</param>
        public History(String value, String password)
        {
            this.value = value;
            this.password = password;
            this.createdAt = DateTime.Now.ToString();
        }
    }
}
