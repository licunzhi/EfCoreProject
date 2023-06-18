using Mapster;

namespace DotnetMapster.Dto;

public class ProductItemDto
{
    // [AdaptIgnore]
    public long? Id { get; set; }
    public long? ItemId { get; set; }
    public string ProductItem { get; set; }
    // [AdaptMember("ItemCount")]
    public int? Count { get; set; }

    public void BeforeMethod()
    {
        Console.WriteLine("Before convert...");
    }
    
    public void AfterMethod()
    {
        Console.WriteLine("After convert...");
    }
}