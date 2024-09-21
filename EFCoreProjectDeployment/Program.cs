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

// a. 自动执行migration脚本---需要注意  Env - Dev Acc Prod
// Jira 敏捷开发
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EFDbContext>();
    db.Database.Migrate();
}

// 生成脚本 
// dotnet ef migrations script -o MigrationScript.sql
// dotnet ef migrations script InitialCreate AddNewColumn -o MyMigrationScript.sql
// 然后通过CICD流程到对应的注意上执行脚本 AzureDevops Jenkins .... Azure Git
// AzureDevops CI build migrations | CD deploy Azure Service + DB ====
// migrations脚本 + AzureDevops commands + Connect DB execute sql
// Prod | acc validation ==> Prod


// Special case : Hotfix
// Git == release branch | main -> hotfix | Migrations files | -> release 发布版本的分支 | -> dev branch
// main + migrations files 09_users   
// dev + migrations files 10_users
// dev => release branch => main ------ 09_users address 10_users address  conflict
// remove duplicate files and  keep one
// _EFMigrationsHistory --- remove duplicate records  XXXXXXXXXXXXXXXXXXXXXX


// commit code , only contains table column change
// local env to connect dev db to develop features

// change table structure in dev, local develop features
// commit code and revert dev db


// Azure Cloud
// Azure Devops + Azure Service (Web + Storage + DB + Application Gateway + Monitor)


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapControllers();
app.Run();