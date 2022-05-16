using Microsoft.EntityFrameworkCore;
using projectoef.models;
using projectoef.models;
namespace projectoef;
 

class TasksContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<projectoef.models.Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

}