using projectoef;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TasksContext>(p => p.UseSqlServer("TasksDb"));
builder.Services.AddSqlServer<TasksContext>("Data Source=SQL5054.site4now.net;Initial Catalog=DB;User Id=DB_admin;Password=Password_2022");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TasksContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();


