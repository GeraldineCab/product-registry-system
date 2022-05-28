using System.ComponentModel.DataAnnotations;
using ProductRegistrySystem.Common.CustomAttributes;

namespace ProductRegistrySystem.Dto.Product
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [ValidStatus]
        public int Status { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
