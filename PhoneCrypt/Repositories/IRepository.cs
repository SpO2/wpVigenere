using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCrypt.Repositories
{
    /// <summary>
    /// Interface for all the entities repositories class.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Host the list of the entities.
        /// </summary>
        ObservableCollection<T> list { get; }
        /// <summary>
        /// Add a T entity in the DataBase.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void add(T entity);
        /// <summary>
        /// Update a T entity in the DataBase.
        /// </summary>
        /// <param name="entity">The entity to update</param>
        void update(T entity);
        /// <summary>
        /// Delete a T entity in the DataBase.
        /// </summary>
        /// <param name="entity">Delete a T entity from the DataBase.</param>
        void delete(T entity);
        /// <summary>
        /// Get a T entityt based on its unique identifier.
        /// </summary>
        /// <param name="Id">The unique identifier of the entity.</param>
        /// <returns>The T entity.</returns>
        T findBy(int Id);
    }
}
