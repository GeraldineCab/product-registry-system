using System.ComponentModel.DataAnnotations;
using ProductRegistrySystem.Common.Utils.CustomAttributes;

namespace ProductRegistrySystem.Dto
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
