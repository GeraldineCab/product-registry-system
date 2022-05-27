using System.Collections.Generic;
using ProductRegistrySystem.Persistence.Entities;

namespace ProductRegistrySystem.Persistence.Utils
{
    public static class DataSeeding
    {
        /// <summary>
        /// Seeds product data
        /// </summary>
        /// <returns>A enumerable of <see cref="Product"/></returns>
        public static IEnumerable<Product> SeedProductData()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Id = 1010,
                    Name = "VESTIDO COMBINADO RIB",
                    Description = "Vestido de escote redondo y tirantes. Bajo combinado a tono.",
                    Status = 1,
                    Price = 109900,
                    Stock = 338
                },
                new Product()
                {
                    Id = 1011,
                    Name = "VESTIDO MINI CON LINO",
                    Description = "Vestido confeccionado con tejido en mezcla de lino.",
                    Status = 1,
                    Price = 179900,
                    Stock = 399
                },
                new Product()
                {
                    Id = 1012,
                    Name = "VESTIDO CORTO FLUIDO",
                    Description = "Vestido corto de escote redondo y tirantes finos ajustables.",
                    Status = 0,
                    Price = 99900,
                    Stock = 429
                },
                new Product()
                {
                    Id = 1013,
                    Name = "VESTIDO MINI APLIQUE CINTURA",
                    Description = "Vestido de escote pico y tirantes finos. Detalle de aplique delantero combinado a tono.",
                    Status = 0,
                    Price = 15900,
                    Stock = 239
                },
                new Product()
                {
                    Id = 1014,
                    Name = "VESTIDO MINI ESTAMPADO ANIMAL CUT OUT",
                    Description =
                        "Vestido de escote pico y tirantes finos. Detalle de aberturas en delantero y espalda.",
                    Status = 1,
                    Price = 179900,
                    Stock = 354
                },
                new Product()
                {
                    Id = 1015,
                    Name = "VESTIDO CORTO CON LINO",
                    Description = "Vestido confeccionado con tejido en mezcla de lino y algodón.",
                    Status = 1,
                    Price = 129900,
                    Stock = 248
                },
                new Product()
                {
                    Id = 1016,
                    Name = "VESTIDO ASIMÉTRICO CORTO",
                    Description = "Vestido de cuello redondo y manga larga asimétrica.",
                    Status = 1,
                    Price = 169900,
                    Stock = 165
                },
                new Product()
                {
                    Id = 1017,
                    Name = "VESTIDO BORDADOS CUELLO",
                    Description = "Vestido de cuello bobo con bordados perforados a tono.",
                    Status = 1,
                    Price = 199900,
                    Stock = 214
                },
                new Product()
                {
                    Id = 1018,
                    Name = "VESTIDO SATINADO CRUZADO",
                    Description = "Vestido mini de cuello solapa con escote pico y manga larga.",
                    Status = 0,
                    Price = 129900,
                    Stock = 318
                },
                new Product()
                {
                    Id = 1019,
                    Name = "VESTIDO FRUNCES ABALORIOS",
                    Description = "Vestido de escote pico y tirantes finos.Tejido con frunces.",
                    Status = 0,
                    Price = 199900,
                    Stock = 284
                }
            };
            
            return products;
        }
    }
}
