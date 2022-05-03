using AutoMapper;
using TraiderMagazine.ProductAPI.Models;
using TraiderMagazine.ProductAPI.Models.Dto;

namespace TraiderMagazine.ProductAPI.AutoMapperConfig
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var config = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<ProductDto, Product>();
                configuration.CreateMap<Product, ProductDto>();
            });

            return config;
        }
    }
}
