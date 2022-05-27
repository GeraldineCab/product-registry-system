namespace ProductRegistrySystem.Persistence.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
