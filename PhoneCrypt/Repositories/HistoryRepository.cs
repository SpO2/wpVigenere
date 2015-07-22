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
        private DataBaseHelper dbHelper;

        public HistoryRepository()
        {
            this.dbHelper = new DataBaseHelper();
        }

        public ObservableCollection<History> list
        {
            get { return this.getAll(); }
        }

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

        public History findBy(int Id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<History> getAll()
        {
            using (dbHelper.dbConn = new SQLiteConnection(DataBaseHelper.DB_PATH))
            {
                List<History> myCollection = dbHelper.dbConn.Table<History>().ToList<History>();
                ObservableCollection<History> historyList = new ObservableCollection<History>(myCollection);
                return historyList;
            } 
        }

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
