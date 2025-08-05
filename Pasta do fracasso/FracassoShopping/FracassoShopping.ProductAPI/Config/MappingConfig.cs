using AutoMapper;
using FracassoShopping.ProductAPI.Data.ValueObjects;
using FracassoShopping.ProductAPI.Model;

namespace FracassoShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
