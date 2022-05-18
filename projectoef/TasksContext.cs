using Microsoft.EntityFrameworkCore;
using projectoef.models;
namespace projectoef;
 

class TasksContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<projectoef.models.Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder){

        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category() { CategoryId = Guid.Parse("1425a7b8-1345-49ad-9755-5095f34f4aaf"), Description = "Activities to do", Name = "Pending Activities", Weight = 20});
        categoriesInit.Add(new Category() { CategoryId = Guid.Parse("1425a7b8-1345-49ad-9755-5095f34f4a02"), Description = "Activities to do", Name = "Personal Activities", Weight = 50});


        modelBuilder.Entity<Category>(category => {
            
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);

            category.Property(p => p.Description).IsRequired(false);
            category.Property(p => p.Weight);

            category.HasData(categoriesInit);

        });

        List<models.Task> tasksInit = new List<models.Task>();
        tasksInit.Add(new models.Task() { TaskId = Guid.Parse("1425a7b8-1345-49ad-9755-5095f34f4a10"), CategoryId = Guid.Parse("1425a7b8-1345-49ad-9755-5095f34f4aaf"), Title = "Task 1", Description = "Task 1 Desc", PriorityTask = Priority.Middle, CreationDate = DateTime.Now });
        tasksInit.Add(new models.Task() { TaskId = Guid.Parse("1425a7b8-1345-49ad-9755-5095f34f4a00"), CategoryId = Guid.Parse("1425a7b8-1345-49ad-9755-5095f34f4a02"), Title = "Task 2", Description = "Task 2 Desc", PriorityTask = Priority.Slow, CreationDate = DateTime.Now });

        modelBuilder.Entity<projectoef.models.Task>(task => {

            task.ToTable("Task");
            task.HasKey(t => t.TaskId);
            task.HasOne(t => t.Category).WithMany(t => t.Tasks).HasForeignKey(t => t.CategoryId);
            task.Property(t => t.CategoryId);
            task.Property(t => t.Title).IsRequired().HasMaxLength(200);
            task.Property(t => t.Description).HasMaxLength(500);
            task.Property(t => t.PriorityTask).IsRequired();
            task.Property(t => t.CreationDate);
            task.Ignore(t => t.Resume);

            task.HasData(tasksInit);
        });
    }

}