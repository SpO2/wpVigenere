using PhoneCrypt.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCrypt.Helpers
{
    public class DataBaseHelper
    {
        /// <summary>
        /// The name of the DataBase.
        /// </summary>
        public const String DB_PATH = "test.db";
        /// <summary>
        /// SQLite connection object.
        /// </summary>
        public SQLiteConnection dbConn;

        /// <summary>
        /// Constructor for the DataBaseHelper object.
        /// </summary>
        public DataBaseHelper()
        {
            if (!CheckFileExists(DB_PATH).Result)
            {
                using (this.dbConn = new SQLiteConnection(DB_PATH))
                {
                    this.dbConn.CreateTable<History>();
                }
            }
        }

        /// <summary>
        /// Check if the Database File is already on the device.
        /// </summary>
        /// <param name="fileName">The name of the Database.</param>
        /// <returns>True if found.</returns>
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        } 

    }
}
