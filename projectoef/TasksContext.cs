using Microsoft.EntityFrameworkCore;
using projectoef.models;
namespace projectoef;
 

class TasksContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<projectoef.models.Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Category>(category => {
            
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);

            category.Property(p => p.Description);
            category.Property(p => p.Weight);

        });

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
        });
    }

}