using DotnetMapster.Dto;
using DotnetMapster.Model;
using Mapster;
using MapsterMapper;

Console.WriteLine("hello world!");
// 单个对象进行转换
// 直接转换
var product = new Product()
{
  Id = 888
};
var productDto = product.Adapt<ProductItemDto>();
Console.WriteLine(productDto);
// 已存在属性转换
var dto = new ProductItemDto()
{
  OrderId = 123
};
var adapt = product.Adapt(dto);
Console.WriteLine(adapt);

// 支持两种位置进行调用，但是一般对象可以直接使用 source.Adapt<destination>(), 值可以使用下面这种，目的是为了避免不必要的拆箱装箱
var result = "123".Adapt<string, long>();
Console.WriteLine(result);

// 集合对象整体转换
var products = new List<Product>() {new()
{
  Id = 1
},
  new()
  {
    Id = 2
  }
};
var orderProductDtos = products.Adapt<List<Product>, List<ProductItemDto>>();
foreach (var orderProductDto in orderProductDtos)
{
  Console.WriteLine(orderProductDto);
}

// 实际上还有对IQueryable的扩展支持
// using (EFDbContext context = new EFDbContext())
// {
//   // 使用 ProjectToType 映射到目标类型
//   var destinations = context.Products.ProjectToType<OrderProductDto>().ToList();
// }

// Console.WriteLine("自定义映射配置：");
// TypeAdapterConfig<Product, ProductItemDto>.NewConfig().Map(dest => dest.ProductItem, src => src.Item);
// var orderProductDto1 = product.Adapt<ProductItemDto>();
// Console.WriteLine(orderProductDto1);

// 后面定义的会生效呢 还是同时会生效呢？ NewConfig()会覆盖之前定义的，但是如果要是使用ForType()的已经定义的会报错的
// 这里需要编写ForType的代码情况
// Console.WriteLine("自定义特殊情况映射配置： ");
// TypeAdapterConfig<Product, ProductItemDto>.NewConfig().Map(dest => dest.ProductItem, src => src.Item, srcCondition => srcCondition.Item == "Water");
// var productDtos = products.Adapt<List<ProductItemDto>>();
// foreach (var orderProductDto in productDtos)
// {
//   Console.WriteLine(orderProductDto.ToString());
// }

Console.WriteLine("忽略特定属性匹配： ");
TypeAdapterConfig<Product, ProductItemDto>.NewConfig().Ignore(dest => dest.Item);
var orderProductDto2 = product.Adapt<ProductItemDto>();
Console.WriteLine(orderProductDto2);

// 执行前后做一些额外的操作, 同样的需要TypeAdaptConfig进行配置
TypeAdapterConfig<Product, ProductItemDto>.NewConfig()
  .BeforeMapping((src, result) => result.BeforeMethod())
  .AfterMapping((src, result) =>  result.AfterMethod());

var productDto1 = product.Adapt<ProductItemDto>();
Console.WriteLine(productDto1);

// 在一些需要进行注入或者工厂累的情况下，可以使用IMapper : 映射器实例
Console.WriteLine("Mapper实例： ");
IMapper mapper = new Mapper();
var mapperDto1 = mapper.Map<ProductItemDto>(product);
Console.WriteLine(mapperDto1);

// 构建器（Builder）
Console.WriteLine("构建器 Builder ： ");
var adaptToType = product.BuildAdapter().AddParameters("Item", "Water")
  .AdaptToType<ProductItemDto>();
Console.WriteLine(adaptToType);

var toType = mapper.From(product).AddParameters("Item", "Water")
  .AdaptToType<ProductItemDto>();
Console.WriteLine(toType);

// 全局设置
TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
TypeAdapterConfig<Product, ProductItemDto>.NewConfig().PreserveReference(false);