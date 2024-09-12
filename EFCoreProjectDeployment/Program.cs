using DotnetMapster.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContext, EFDbContext>();

var app = builder.Build();

// a. 自动执行migration脚本---需要注意
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EFDbContext>();
    db.Database.Migrate();
}

// 生成脚本 
// dotnet ef migrations script -o MigrationScript.sql
// dotnet ef migrations script InitialCreate AddNewColumn -o MyMigrationScript.sql
// 然后通过CICD流程到对应的注意上执行脚本


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapControllers();
app.Run();