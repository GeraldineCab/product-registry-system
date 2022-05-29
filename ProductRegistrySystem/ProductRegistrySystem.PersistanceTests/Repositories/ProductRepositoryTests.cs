using NUnit.Framework;
using ProductRegistrySystem.Persistence;
using ProductRegistrySystem.Persistence.Repositories;
using ProductRegistrySystem.PersistenceTests.Helpers;

namespace ProductRegistrySystem.PersistenceTests.Repositories
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private ProductRepository _repository;
        private ProductRegistrySystemDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new ProductRegistrySystemDbContext(ServicesConfigurationHelper.GetIConfigurationRoot());
            _repository = new ProductRepository(_context);
        }

        [Test]
        public void Can_Load_Product()
        {
            // Arrange
            var product = _repository.GetById(1010);

            // Assert
            Assert.IsNotNull(product);
        }
    }
}
