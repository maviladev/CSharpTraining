using projectoef;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("cnTasks"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TasksContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) => 
{
    return Results.Ok(dbContext.Tasks.Include(c => c.Category));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] projectoef.models.Task task) => 
{
    task.TaskId = Guid.NewGuid();
    task.CreationDate = DateTime.Now;
    await dbContext.AddAsync(task);

    // Another way to do this
    // await dbContext.Tasks.AddAsync(task);

    await dbContext.SaveChangesAsync();

    return Results.Ok();

});

app.MapPut("/api/tasks/{taskid}", async ([FromServices] TasksContext dbContext, [FromBody] projectoef.models.Task task, [FromRoute] Guid taskId) => 
{
    var currentTask = dbContext.Tasks.Find(taskId);

    if(currentTask != null){
        
        currentTask.CategoryId = task.CategoryId;
        currentTask.Title = task.Title;
        currentTask.PriorityTask = task.PriorityTask;
        currentTask.Description = task.Description;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();

});


app.Run();


