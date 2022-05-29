using System.Globalization;
using AutoMapper;
using ProductRegistrySystem.Dto.Product;
using ProductRegistrySystem.Persistence.Entities;

namespace ProductRegistrySystem.Business.Mappers
{
    public class ProductMapper
    {
        public IMapper Mapper => _mapper;

        private static readonly IMapper _mapper = InitializeMapper();

        private static IMapper InitializeMapper()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDto>()
                    .ForMember(dest => 
                        dest.Price,
                        opt => opt.MapFrom(p => p.Price.ToString(CultureInfo.CurrentCulture)))
                    .ForMember(dest => 
                        dest.Discount, 
                        opt => opt.Ignore())
                    .ForMember(dest =>
                        dest.FinalPrice,
                        opt => opt.Ignore())
                    .ForMember(dest => 
                        dest.StatusName,
                        opt => opt.Ignore());
            });
            configuration.AssertConfigurationIsValid();

            return configuration.CreateMapper();
        }

        public ProductDto Get(Product entity)
        {
            return entity == null ? null : _mapper.Map<Product, ProductDto>(entity);
        }
    }
}
