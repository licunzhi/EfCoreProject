using DotnetMapster.Model;

namespace MapsterOnApiProject.Model;

public class ItemDetail
{
    public long Id { get; set; }

    public string ItemName { get; set; }
    public decimal UnitPrice { get; set; }

    public Product Product { get; set; }
    public long ProductId { get; set; }
}