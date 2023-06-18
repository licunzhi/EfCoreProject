using DotnetMapster.Dto;
using DotnetMapster.Model;
using Mapster;
using MapsterOnApiProject.Model;

namespace MapsterOnApiProject.ServiceExtensions;

public static class MapsterMappingExtension
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        // simple class to class configuration
        TypeAdapterConfig<Product, ProductItemDto>
            .NewConfig()
            .Map(dest => dest.ProductItem, src => src.ItemDetail.ItemName)
            .Map(dest => dest.ItemId, src => src.ItemDetail.Id)
            .BeforeMapping((src, dest) => dest.BeforeMethod())
            .AfterMapping((src, dest) => dest.AfterMethod());

        // multi classes to class configuration
        TypeAdapterConfig<(Product, ItemDetail), ProductItemDto>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Item1.Id)
            .Map(dest => dest.Count, src => src.Item1.ItemCount)
            .Map(dest => dest.ProductItem, src => src.Item2.ItemName)
            .Map(dest => dest.ItemId, src => src.Item2.Id);
    }
}