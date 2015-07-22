using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCrypt.Repositories
{
    public interface IRepository<T>
    {
        ObservableCollection<T> list { get; }
        void add(T entity);
        void update(T entity);
        void delete(T entity);
        T findBy(int Id);
    }
}
