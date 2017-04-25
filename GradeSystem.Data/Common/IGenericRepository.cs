using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GradeSystem.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Marks an entity as new
        T Add(T entity);

        // Marks an entity as modified
        void Edit(T entity);

        // Marks an entity to be removed
        T Delete(T entity);

        void Save();

        // Gets all entities of type T
        IEnumerable<T> GetAll();

        // Gets entities using delegate
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
