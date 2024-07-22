using DotnetMapster.Data;
using DotnetMapster.Model;
using MapsterOnApiProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTransaction.Controllers;

[ApiController]
[Route("[controller]")]
public class TestDemoController : ControllerBase
{
    private readonly EFDbContext _efDbContext;

    public TestDemoController(EFDbContext efDbContext)
    {
        _efDbContext = efDbContext;
    }

    [HttpGet("insert-with-translation")]
    public async Task<IActionResult> InsertWithTranslation()
    {
        // 开启事务方法
        await using var transaction = await _efDbContext.Database.BeginTransactionAsync();
        try
        {
            // 创建对象，保存对象信息
            await _efDbContext.Products.AddAsync(new Product()
            {
                ItemCount = 1,
                ItemDetail = new ItemDetail()
                {
                    ItemName = "ball",
                    UnitPrice = 100
                }
            });

            await _efDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            // 异常情况，进行回滚操作
            await transaction.RollbackAsync();
        }
        return Ok();
    }
    
    [HttpGet("insert-with-error-translation")]
    public async Task<IActionResult> InsertWithErrorTranslation()
    {
        // 开启事务方法
        await using var transaction = await _efDbContext.Database.BeginTransactionAsync();
        try
        {
            // 创建对象，保存对象信息
            await _efDbContext.Products.AddAsync(new Product()
            {
                ItemCount = 1
            });
            await _efDbContext.SaveChangesAsync();

            await _efDbContext.ItemDetails.AddAsync(new ItemDetail()
            {
                ItemName = "dog",
                UnitPrice = 1000
            });
            await _efDbContext.SaveChangesAsync();
            
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            // 异常情况，进行回滚操作
            await transaction.RollbackAsync();
            throw;
        }
        return Ok();
    }
}