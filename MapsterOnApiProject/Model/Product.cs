using MapsterOnApiProject.Model;

namespace DotnetMapster.Model;

public class Product
{
    //主键
    public long Id { get; set; }
    // Item的数量信息
    public int ItemCount { get; set; }
    
    // 和Item之间的关联关系
    public ItemDetail ItemDetail { get; set; }
}