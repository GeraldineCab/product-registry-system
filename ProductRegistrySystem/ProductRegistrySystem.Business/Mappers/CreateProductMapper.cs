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
                config.CreateMap<CreateProductDto, Product>()
                    .ForMember(dest =>
                        dest.Id,
                        opt => opt.Ignore());
            });
            configuration.AssertConfigurationIsValid();

            return configuration.CreateMapper();
        }

        public Product Get(CreateProductDto dto)
        {
            return dto == null ? null : _mapper.Map<CreateProductDto, Product>(dto);
        }
    }
}
