using AmazonPizza.Services.ProductAPI.Model;
using AmazonPizza.Services.ProductAPI.Model.Dto;
using AutoMapper;

namespace AmazonPizza.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductsDto, Product>();
                config.CreateMap<Product, ProductsDto>();
            });

            return mappingConfig;
        }
    }
}
