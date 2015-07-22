using PhoneCrypt.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneCrypt.Helpers;

namespace PhoneCrypt.Repositories
{
    /// <summary>
    /// Repository class access for the History entity.
    /// </summary>
    public class HistoryRepository:IRepository<History>
    {
        /// <summary>
        /// DataBaseHelper object.
        /// </summary>
        private DataBaseHelper dbHelper;

        /// <summary>
        /// Constructor for the HistoryRepository object.
        /// </summary>
        public HistoryRepository()
        {
            this.dbHelper = new DataBaseHelper();
        }

        /// <summary>
        /// Property that host the History's List.
        /// </summary>
        public ObservableCollection<History> list
        {
            get { return this.getAll(); }
        }

        /// <summary>
        /// Add a History entity in the DataBase.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void add(History entity)
        {
            using (dbHelper.dbConn = new SQLiteConnection(DataBaseHelper.DB_PATH))
            {
                dbHelper.dbConn.RunInTransaction(() =>
                {
                    dbHelper.dbConn.Insert(entity);
                });
            } 
        }

        /// <summary>
        /// Update a History entity in the DataBase.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public void update(History entity)
        {
            using (dbHelper.dbConn = new SQLiteConnection(DataBaseHelper.DB_PATH))
            {
                History existingHistory = dbHelper.dbConn.Query<History>("select * from History where Id = ?", entity.id).FirstOrDefault();
                if (existingHistory != null)
                {
                    existingHistory.createdAt = entity.createdAt;
                    existingHistory.value = entity.value;
                    existingHistory.password = entity.password;
                    dbHelper.dbConn.RunInTransaction(() =>
                    {
                        dbHelper.dbConn.Update(existingHistory);
                    });
                }
            } 
        }

        /// <summary>
        /// Delete a history entity from the DataBase.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public void delete(History entity)
        {
            using (dbHelper.dbConn = new SQLiteConnection(DataBaseHelper.DB_PATH))
            {
                var existingHistory = dbHelper.dbConn.Query<History>("select * from History where Id = ?", entity.id).FirstOrDefault();
                if (existingHistory != null)
                {
                    dbHelper.dbConn.RunInTransaction(() =>
                    {
                        dbHelper.dbConn.Delete(existingHistory);
                    });
                }
            } 
        }

        /// <summary>
        /// Find an History entity based on its Id field.
        /// </summary>
        /// <param name="Id">The unique identifier of the History entity.</param>
        /// <returns>The History entity.</returns>
        public History findBy(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the list of the History entities from the DataBase.
        /// </summary>
        /// <returns>The list of the History entities.</returns>
        public ObservableCollection<History> getAll()
        {
            using (dbHelper.dbConn = new SQLiteConnection(DataBaseHelper.DB_PATH))
            {
                List<History> myCollection = dbHelper.dbConn.Table<History>().ToList<History>();
                ObservableCollection<History> historyList = new ObservableCollection<History>(myCollection);
                foreach (History h in historyList)
                {
                    h.setOrientationImg(h.orientation);
                }
                return historyList;
            } 
        }

        /// <summary>
        /// Delete all the History entities from the DataBase.
        /// </summary>
        public void deleteAll()
        {
            using (dbHelper.dbConn = new SQLiteConnection(DataBaseHelper.DB_PATH))
            {
                dbHelper.dbConn.DropTable<History>();
                dbHelper.dbConn.CreateTable<History>();
            }
        }
    }
}
