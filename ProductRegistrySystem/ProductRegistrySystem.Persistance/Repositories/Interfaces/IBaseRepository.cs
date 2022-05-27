using System.Threading;
using System.Threading.Tasks;

namespace ProductRegistrySystem.Persistence.Repositories.Interfaces
{
    public interface IBaseRepository<T> 
    {
        /// <summary>
        /// Gets a single record of the given type
        /// </summary>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Adds a record of the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Add(T entity);

        /// <summary>
        /// Updates a record of the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Update(T entity);

        /// <summary>
        /// Persists data
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
