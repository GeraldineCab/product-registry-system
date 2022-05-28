using AutoMapper;
using ProductRegistrySystem.Dto.Product;
using ProductRegistrySystem.Persistence.Entities;

namespace ProductRegistrySystem.Business.Mappers
{
    public class CreateProductMapper
    {
        public IMapper Mapper => _mapper;

        private static readonly IMapper _mapper = InitializeMapper();

        private static IMapper InitializeMapper()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateProductDto, Product>();
            });
            configuration.AssertConfigurationIsValid();

            return configuration.CreateMapper();
        }

        public Product Get(CreateProductDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return _mapper.Map<CreateProductDto, Product>(dto);
        }
    }
}
