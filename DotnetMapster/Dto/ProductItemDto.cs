using System;

namespace DotnetMapster.Dto;

public class ProductItemDto
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public string Item { get; set; }
    public string ProductItem { get; set; }
    public int Count { get; set; }

    public override string ToString()
    {
        return $"Id : {Id}, OrderId : {OrderId}, Item : {Item}, ProductItem : {ProductItem}, Count: {Count}";
    }

    public void BeforeMethod()
    {
        Console.WriteLine("Before convert...");
    }
    
    public void AfterMethod()
    {
        Console.WriteLine("After convert...");
    }
}