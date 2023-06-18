using DotnetMapster.Dto;
using DotnetMapster.Model;
using Mapster;
using MapsterOnApiProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace MapsterOnApiProject.Controllers;

[ApiController]
[Route("[controller]")]
public class TestMapsterController
{

    [HttpGet("simple-class-convert")]
    public Task<ProductItemDto> SimpleClassConvert()
    {
        var product = new Product()
        {
            Id  = 1,
            ItemCount = 100
        };
        // 直接转换
        var productItemDto = product.Adapt<ProductItemDto>();
        return Task.FromResult(productItemDto);
    }
    
    // 配置转换
    [HttpGet("config-class-convert")]
    public Task<ProductItemDto> ConfigClassConvert()
    {
        var itemDetail = new ItemDetail()
        {
            Id = 12,
            ItemName = "Coffee"
        };
        
        var product = new Product()
        {
            Id  = 1,
            ItemCount = 100,
            ItemDetail = itemDetail
        };
        var productItemDto = product.Adapt<ProductItemDto>();
        return Task.FromResult(productItemDto);
    }
    
    // 追加参数
    [HttpGet("append-parameters-class-convert")]
    public Task<ProductItemDto> AppendParametersClassConvert()
    {
        var itemDetail = new ItemDetail()
        {
            Id = 12,
            ItemName = "Coffee"
        };
        
        var product = new Product()
        {
            Id  = 1,
            ItemCount = 100,
            ItemDetail = itemDetail
        };

        var adaptToType = product.BuildAdapter().AddParameters("OperatorName", "123")
            .AdaptToType<ProductItemDto>();
        return Task.FromResult(adaptToType);
    }
    
    // 复杂数据源配置
    [HttpGet("multiple-source-class-convert")]
    public Task<ProductItemDto> MultipleSourceClassConvert()
    {
        var itemDetail = new ItemDetail()
        {
            Id = 12,
            ItemName = "Coffee"
        };
        
        var product = new Product()
        {
            Id  = 1,
            ItemCount = 100,
        };

        var productItemDto = (product, itemDetail).Adapt<ProductItemDto>();
        return Task.FromResult(productItemDto);
    }
}