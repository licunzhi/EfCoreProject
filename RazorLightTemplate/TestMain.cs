using RazorLight;

namespace RazorLightTemplate;

public class TestMain
{
    static async Task Main(string[] args)
    {
        var razorLightEngine = new RazorLightEngineBuilder()
            .UseFileSystemProject(Path.Combine("/Users/licunzhi/RiderProjects/EfCoreProject/RazorLightTemplate/Template"))
            .UseMemoryCachingProvider()
            .Build();
        var result = await razorLightEngine.CompileRenderAsync("Template01.cshtml", new { Name = "RazorLight" });
        
        Console.Write(result);
    }
}