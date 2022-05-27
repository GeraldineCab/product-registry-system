using ProductRegistrySystem.Persistence.Entities;
using ProductRegistrySystem.Persistence.Repositories.Interfaces;

namespace ProductRegistrySystem.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductRegistrySystemDbContext context) : base(context) { }
    }
}
