using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductRegistrySystem.Persistence.Repositories.Interfaces;

namespace ProductRegistrySystem.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ProductRegistrySystemDbContext _dbContext;
        internal DbSet<T> DbSet;

        public BaseRepository(ProductRegistrySystemDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = _dbContext?.Set<T>();
        }

        /// <inheritdoc />
        public T GetById(int id)
        {
            return _dbContext.Find<T>(id);
        }

        /// <inheritdoc />
        public void Add(T entity)
        {
            DbSet?.Add(entity);
        }

        /// <inheritdoc />
        public void Update(T entity)
        {
            DbSet?.Update(entity);
        }

        /// <inheritdoc />
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext?.SaveChangesAsync(cancellationToken);
        }
    }
}
